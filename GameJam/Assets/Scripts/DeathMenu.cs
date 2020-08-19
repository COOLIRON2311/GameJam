using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject DeathMenuUI;
    public GameObject Camera;
    public bool PlayerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied(Vector2 deathPos)
    {
        if (PauseMenu.Paused)
        {
            GetComponent<PauseMenu>().Resume();
        }
        if (Camera)
        {
            GameObject empty = new GameObject();
            Instantiate(empty);
            empty.transform.position = deathPos;
            CameraController cc = Camera.GetComponent<CameraController>();
            if (cc)
            {
                cc.SetFollowing(empty);
            }
        }

        //Time.timeScale = 0f;
        DeathMenuUI.SetActive(true);
        PlayerDead = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SaveManager.LoadGame();
    }
}
