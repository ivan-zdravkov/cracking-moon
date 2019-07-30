using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int breakableBlocks = 0;
    int balls = 0;

    public void CountBlocks()
    {
        this.breakableBlocks++;
    }

    public void CountBalls()
    {
        this.balls++;
    }

    public void BlockDestroyed()
    {
        this.breakableBlocks--;

        if (breakableBlocks <= 0)
            FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void BallDroped()
    {
        this.balls--;

        if (this.balls <= 0)
            SceneManager.LoadScene("GameOver");
    }
}
