using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject loseScreen, winScreen;
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        loseScreen.SetActive(false);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
        winScreen.SetActive(false);
    }

    public void goToTutorial()
    {
        SceneManager.LoadScene(0);
        winScreen.SetActive(false);
    }
}
