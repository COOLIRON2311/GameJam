using System.IO;
using UnityEngine.SceneManagement;

public static class SaveManager
{
    private static readonly string path = "Assets/savedgame";
    public static void NewGame()
    {
        var save = new string[] {"0", "1"}; // "humanity" level, scene number
        File.WriteAllLines(path, save);
    }
        
    public static void LoadGame()
    {
        try
        {
            var save = File.ReadAllLines(path);
            // ...
            // TODO Load "humanity" level (save[0])
            SceneManager.LoadScene(int.Parse(save[1]));
        }
        catch (FileNotFoundException)
        {
            // No save file found
        }
    }
    public static void SaveGame(int humanity = 0)
    {
        var save = new string[] {humanity.ToString(), SceneManager.GetActiveScene().buildIndex.ToString()};
        File.WriteAllLines(path, save);
    }
}
