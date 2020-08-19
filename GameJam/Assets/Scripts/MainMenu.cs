using UnityEngine;
using static SaveManager;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SaveManager.NewGame();
        SaveManager.LoadGame();
    }
    public void LoadGame()
    {
        SaveManager.LoadGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
