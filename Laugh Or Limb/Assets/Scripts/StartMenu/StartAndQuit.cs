using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndQuit : MonoBehaviour
{
    public string SceneName;


    public void StartGame()
    {
        Debug.Log("StartingGame");
        SceneManager.LoadScene(SceneName);
    }
    public void EndGame()
    {
        Debug.Log("Quitting the Game");
        Application.Quit();
    }
}
