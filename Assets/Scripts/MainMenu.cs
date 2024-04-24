using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    
    //this function will quit the game
    public void QuitGame()
    {
        Debug.Log("QUIT!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    //this function will load the leaderboard
    public void goLeaderboard(){
        SceneManager.LoadScene(1);
    }

    //this function will load the main menu
    public void goMainMenu()
    {
        SceneManager.LoadScene(2);
    }
}
