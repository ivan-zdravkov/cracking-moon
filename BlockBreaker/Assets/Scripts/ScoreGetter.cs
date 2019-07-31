using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = FindObjectOfType<GameSession>().GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
