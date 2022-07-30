using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SwerveMovement player;
    public Transform stack;
    [SerializeField] private GameObject gameWinPanel, gameLosePanel;

    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] private GameObject startText, highScore;

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

        if (scoreCount != 0)
        {
            scoreCount--;
            scoreText.text = scoreCount.ToString();
            for (int i = stack.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            scoreCount = 0;
        }
        healthCount--;
        healthImage[healthCount].gameObject.SetActive(false);

        if(healthCount == 0)
        {
            GameLose();
        }
    }
    public void GameWin()
    {
        if(scoreCount > 10)
        {
            highScore.SetActive(true);
            highScoreText.text = "HIGH SCORE: " + scoreText.text;
            player.anim.SetBool("isFinish", true);
            StartCoroutine(WaitForHighScore());
        }
        else
        {
            gameWinPanel.SetActive(true);
        }
    }
    public void GameLose()
    {
        Time.timeScale = 0;
        gameLosePanel.SetActive(true);
        
    }
    public  void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator WaitForHighScore()
    {
        yield return new WaitForSeconds(0.1f);
        player.anim.SetBool("isFinish", false);
    }
}
