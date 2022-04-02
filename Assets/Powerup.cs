using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    public Motivator motivator;
    public Button powerupButton;
    public Vector2 pushdownAmount;
    public void PushSnowDown()
	{
        motivator.snowTransform.Translate(pushdownAmount);
	}
}
