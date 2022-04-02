using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver { get; set; } = false;
    public static Snow Snow { get; set; }

    private Camera cam;

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
    }

    private void GameOver()
    {
        IsGameOver = true;
        Debug.Log("Game over!");
    }
}
