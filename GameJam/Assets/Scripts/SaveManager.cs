using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveManager
{
    private static readonly string path = "Assets/savedgame";
    public static void NewGame()
    {
        var save = new string[] {"1", "1", "0"}; // scene number, spawn point number, "humanity" level
        File.WriteAllLines(path, save);
    }
        
    public static void LoadGame()
    {
        try
        {
            var save = File.ReadAllLines(path);
            SceneManager.LoadScene(int.Parse(save[0]));
            // TODO Teleport player to specific (s)pwn point (save[1])
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
}
