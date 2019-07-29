using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int score = 0;

    void Awake()
    {
        bool isFirst = FindObjectsOfType<GameStatus>().Length == 1;

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
        this.scoreText.SetText(this.score.ToString());
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        this.score += this.pointsPerBlock;
        this.scoreText.SetText(this.score.ToString());
    }
}