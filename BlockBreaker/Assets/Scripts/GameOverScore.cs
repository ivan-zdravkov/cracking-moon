using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string scoreText = FindObjectOfType<GameSession>().GetScore().ToString();

        this.GetComponent<TextMeshProUGUI>().SetText(scoreText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
