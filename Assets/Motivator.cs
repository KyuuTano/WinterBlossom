using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Motivator : MonoBehaviour
{
    public Transform snowTransform;
    public Transform playerTransform;

	public bool isGameOver;

	public Text gameOverText;
	public int snowSpeed;

	//public Rigidbody2D snowRB;

	public Collider2D playerCollider;
	public Rigidbody2D snowRB;

	private void Start()
	{
		isGameOver = false;
	}
	private void Update()
	{
		if(!isGameOver)
			snowRB.MovePosition(transform.position + Vector3.up * snowSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("collided");
		isGameOver = true;
		gameOverText.gameObject.SetActive(true);
	}

}
