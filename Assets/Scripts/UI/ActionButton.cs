using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        Debug.Log("Play Action");
        SceneManager.LoadScene("Game");
    }
    public void rePlay()
    {
        Debug.Log("rePlay Action");
        SceneManager.LoadScene("Game");
    }

    public void loadMainMenu()
    {
        Debug.Log("loadMainMenu Action");
        SceneManager.LoadScene("MainMenu");
    }

    public void loadAttackWin()
    {
        SceneManager.LoadScene("Attack_win");
    }
    public void loadDefenseWin()
    {
        SceneManager.LoadScene("Defense_win");
    }

    public void Exit()
    {
        Debug.Log("Exit Action");
        Application.Quit();
    }
}
