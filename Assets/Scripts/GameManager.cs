using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    //[SerializeField] public static bool IsGameOver = false;
    [SerializeField] private float panelMoveUpValue;

    public bool IsGameOver;
    public bool isGamePaused = false;
    public static Snow Snow { get; set; }

    public Text timeText;
    public Text timeTakenText;
    public Text scoreText;
    public Text highScoreText;

    private double timeStart;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject playerObject;
    public GameObject pauseButton;
    public GameObject fadePanel;
    public GameObject snow;

    public int scoreMultiplier;
    public int fadeAlphaValue;

    private Camera cam;

    [SerializeField] GameObject GameMusic;
    [SerializeField] GameObject DeathMusic;

    public static Action OnPowerupCollected;

    void Start()
    {
        cam = Camera.main;

    }

    void Update()
    {
        float camTop = cam.transform.position.y + cam.orthographicSize;

        if (!IsGameOver)
        {
            if (Snow.Height > camTop)
            {
                GameOver();
            }
            timeStart += Time.deltaTime;
            timeText.text = "Time: " + timeStart.ToString("F2");
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space))
            PauseOrResumeGame();

    }

    public void GameOver()
    {
        IsGameOver = true;
        float totalTime = (float)timeStart;
        int myscore = Mathf.RoundToInt(totalTime * scoreMultiplier);
        timeText.gameObject.SetActive(false);


        AnimateFading();
        AnimatePanel();


        timeTakenText.text = "Time: " + totalTime.ToString("F2");
        scoreText.text = "Score: " + myscore;


        RecordHighScore(myscore);
        //Debug.Log("Game over!");
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");

        playerObject.SetActive(false);
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        GameMusic.SetActive(false);
        DeathMusic.SetActive(true);


    }

    private void AnimateFading()
    {
        fadePanel.GetComponent<Image>().DOFade(fadeAlphaValue / 255f, .5f);
    }
    private void AnimatePanel()
    {
        gameOverPanel.transform.DOMoveY(panelMoveUpValue, 1.5f).SetEase(Ease.InOutBack);

    }
    public void OnRetryClicked()
    {
        ResetGame();
    }

    public void OnMainMenuClicked()
    {
        QuitGame();
    }

    private void ResetGame()
    {
        //SceneManager.LoadScene("Replace Game Panel Sprites");

        //USE THIS FUNCTION AFTER MERGING!!!
        SceneManager.LoadScene("Main");
        DOTween.KillAll();
    }

    public void PauseOrResumeGame()
    {
        if (!isGamePaused)
        {
            isGamePaused = true;
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            timeText.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            isGamePaused = false;
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
            timeText.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
        DOTween.KillAll();
    }

    private void RecordHighScore(int highscore)
    {
        if (highscore > PlayerPrefs.GetInt("High Score"))
            PlayerPrefs.SetInt("High Score", highscore);
    }
}
