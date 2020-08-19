using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSaver : MonoBehaviour
{
    int SpawnPointNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPointNumber = int.Parse(gameObject.name.Replace("SpawnPoint", ""));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            if (SaveManager.SavedScene < SceneManager.GetActiveScene().buildIndex || SaveManager.SavedSpawnPoint < SpawnPointNumber)
            {
                //TODO: HUMANITY!
                SaveManager.SaveGame(SpawnPointNumber, 0);
            }
        }
    }
}
