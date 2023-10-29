using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoLvl1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void GoLvl2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void GoLvl3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void GoCartas()
    {
        SceneManager.LoadScene("Cartas");
    }
}
