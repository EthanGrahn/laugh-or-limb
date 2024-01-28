using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndQuit : MonoBehaviour
{
    public string startGame;
    public string credits;
    public string mainMenu;

    public void StartGame()
    {
        Debug.Log("StartingGame");
        SceneManager.LoadScene(startGame);
    }

    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene(credits);
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(mainMenu);
    }

    public void EndGame()
    {
        Debug.Log("Quitting the Game");
        Application.Quit();
    }
}
