using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameWinPanel, gameLosePanel;

    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] private GameObject startText;

    [SerializeField] private GameObject [] healthImage;

    [SerializeField] private int scoreCount = 0;
    [SerializeField] private int healthCount = 3;
    public bool gameStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            startText.SetActive(false);
        }
    }
    public void HitCollectible()
    {
        scoreCount++;
        scoreText.text = scoreCount.ToString();
    }
    public void HitEnemy()
    {
        scoreCount--;
        scoreText.text = scoreCount.ToString();
        healthCount--;
        for(int i = healthImage.Length; i >= 0; i++)
        {
            healthImage[i].SetActive(false);
        }
        if(healthCount == 0)
        {
            GameLose();
        }
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        if(scoreCount > 10)
        {
            highScoreText.text = "HIGH SCORE: " + scoreText.text;
        }
    }
    public void GameLose()
    {
        gameLosePanel.SetActive(true);
        
    }
    public  void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
