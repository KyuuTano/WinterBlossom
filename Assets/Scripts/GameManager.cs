using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] public static bool IsGameOver = false;
    public bool IsGameOver;
    public static Snow Snow { get; set; }

    public Text timeText;
    public Text timeTakenText;

    public double timeStart;

    public GameObject gameOverPanel;
    public GameObject playerObject;

    private Camera cam;

    [SerializeField] GameObject GameMusic;
    [SerializeField] GameObject DeathMusic;

    void Start()
    {
        cam = Camera.main;

    }

    void Update()
    {
        float camTop = cam.transform.position.y + cam.orthographicSize;

        if (!IsGameOver && Snow.Height > camTop)
        {
            GameOver();
        }
        if (!IsGameOver)
        {
            timeStart += Time.deltaTime;
            timeText.text = "Time: " + timeStart.ToString("F2");
        }

    }

    public void GameOver()
    {
        IsGameOver = true;
        float totalTime = (float)timeStart;
        timeTakenText.text = "Time: " + totalTime.ToString("F2");
        Debug.Log("Game over!");
        playerObject.SetActive(false);
        gameOverPanel.SetActive(true);
        GameMusic.SetActive(false);
        DeathMusic.SetActive(true);
    }

    public void OnRetryClicked()
    {
        ResetGame();
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("Title");
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("Main");

        //IsGameOver = false;
        //gameOverPanel.SetActive(false);
        //playerObject.gameObject.SetActive(true);
        //timeStart = 0;

    }
}
