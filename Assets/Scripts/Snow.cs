using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public float baseRiseSpeed = 1.0f;
    public float riseAccel = 1.0f;
    public float lerpSpeed = 50.0f;

    public GameManager gm;
    public float Height { get => height; }

    [SerializeField] float MaxSpeed = 4f;

    private float height = 0.0f;
    private float riseSpeed = 0.0f;

    void Start()
    {
        riseSpeed = baseRiseSpeed;
        height = transform.position.y;

        GameManager.Snow = this;
    }

    void Update()
    {
        if (!gm.IsGameOver)
        {
            height += riseSpeed * Time.deltaTime;
            riseSpeed += Mathf.Min(riseAccel * Time.deltaTime, MaxSpeed);

            Vector3 newPosition = transform.position;
            newPosition.y = height;
            transform.position = Vector3.Lerp(transform.position, newPosition, lerpSpeed * Time.deltaTime);
        }



    }

    public void Nerf(float heightDelta, float speedDelta)
    {
        height += heightDelta;
        riseSpeed = Mathf.Max(riseSpeed + speedDelta, baseRiseSpeed);
    }
}