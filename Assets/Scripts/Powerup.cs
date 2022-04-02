using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float snowHeightDelta = -1f;
    public float snowRiseSpeedDelta = -1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Activate();
        }
    }

    private void Activate()
    {
        GameManager.Snow.Nerf(snowHeightDelta, snowRiseSpeedDelta);
        GameObject.Destroy(this.gameObject);
    }
}
