using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class PopUpMessage
{
    static GameObject CurrentMessage;
    static GameObject PopUpCanvas;
    static GameObject Player;
    static int LastLevel;

    //STOLEN!
    public static IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    static bool FindCurrentCanvas()
    {
        if (!PopUpCanvas || LastLevel < SceneManager.GetActiveScene().buildIndex)
        {
            //TODO: Fix shitty approach
            PopUpCanvas = GameObject.Find("PopUpCanvas");
            if (!PopUpCanvas)
            {
                Debug.LogWarning("Can't find PopUpCanvas!");
                return false;
            }
            LastLevel = SceneManager.GetActiveScene().buildIndex;
        }
        return true;
    }

    static bool FindPlayer()
    {
        if (!Player)
        {
            //TODO: Fix shitty approach
            Player = GameObject.Find("player");
            if (!Player)
            {
                Debug.LogWarning("Can't find player!");
                return false;
            }
        }
        return true;
    }

    public static void ShowPopUpMessage(string text)
    {
        if (FindCurrentCanvas() && FindPlayer())
        {
            PopUpCanvas.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 1f);
            Text t = PopUpCanvas.transform.GetChild(0).GetComponent<Text>();
            t.text = text;
            t.StartCoroutine(FadeTextToZeroAlpha(2.5f, t));
        }
    }
}
