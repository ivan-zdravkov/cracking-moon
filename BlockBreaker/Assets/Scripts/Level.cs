using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int breakableBlock;

    public void CountBlocks()
    {
        this.breakableBlock++;
    }

    public void BlockDestroyed()
    {
        this.breakableBlock--;

        if (breakableBlock <= 0)
            FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
