using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEnding : MonoBehaviour
{
   public void RestartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
