using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            this.ResetGame();
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void ResetGame()
    {
        FindObjectOfType<GameSession>().ResetGame();

        SceneManager.LoadScene(0);
    }
}