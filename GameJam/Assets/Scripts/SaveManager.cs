using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveManager
{
    private static readonly string path = "Assets/savedgame";
    public static int SavedSpawnPoint = 1;
    public static int SavedScene = 1; 

    public static void NewGame()
    {
        var save = new string[] {"1", "1", "0"}; // scene number, spawn point number, "humanity" level
        File.WriteAllLines(path, save);
        // SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        LoadGame();
    }
        
    public static void LoadGame()
    {
        try
        {
            var save = File.ReadAllLines(path);
            SavedScene = int.Parse(save[0]);
            SceneManager.LoadScene(SavedScene);
            SceneManager.sceneLoaded += OnSceneLoaded;
            //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(SavedScene));
            SavedSpawnPoint = int.Parse(save[1]);
            
        }
        catch (FileNotFoundException)
        {
            // No save file found
        }
    }

    
    public static void SaveGame(int spawn_point = 1, int humanity = 0)
    {
        var save = new string[] {SceneManager.GetActiveScene().buildIndex.ToString(), spawn_point.ToString(), humanity.ToString()};
        File.WriteAllLines(path, save);
    }
    public static int RestoreHumanity()
    { // Should be called from some level script
        var save = File.ReadAllLines(path);
        return int.Parse(save[2]);
    }

    public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject loadedSpawn = spawnPoints.FirstOrDefault(x => int.Parse(x.name.Replace("SpawnPoint", "")) == SavedSpawnPoint);

        if (loadedSpawn)
        {
            GameObject player = GameObject.Find("player");
            player.transform.position = loadedSpawn.transform.GetChild(0).transform.position;
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
