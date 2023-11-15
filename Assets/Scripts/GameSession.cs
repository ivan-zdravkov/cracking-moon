using System;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int score = 0;
    [SerializeField] bool isAutoPlayEnabled = false;

    void Awake()
    {
        bool isFirst = FindObjectsOfType<GameSession>().Length == 1;

        if (isFirst)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            this.gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }

    void Start()
    {
        this.UpdateScore();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
            this.isAutoPlayEnabled = !this.isAutoPlayEnabled;

        if (this.gameSpeed < 10 && (Input.GetKeyDown(KeyCode.UpArrow)))
            this.gameSpeed += 1f;

        if (this.gameSpeed > 1 && (Input.GetKeyDown(KeyCode.DownArrow)))
            this.gameSpeed -= 1f;
    }

    public int GetScore()
    {
        return this.score;
    }

    public bool IsAutoPlayEnabled
    {
        get
        {
            return isAutoPlayEnabled;
        }
    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }

    public void AddToScore()
    {
        this.score += this.pointsPerBlock;

        this.UpdateScore();
    }

    private void UpdateScore()
    {
        if (this.scoreText)
            this.scoreText.SetText(this.score.ToString());
    }
}