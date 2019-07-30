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
        this.scoreText.SetText(this.score.ToString());
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
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
        this.scoreText.SetText(this.score.ToString());
    }
}