using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float snowHeightDelta = -1f;
    public float snowRiseSpeedDelta = -1f;

    [Range(0f, 1f)]
    [SerializeField] float chanceToSpawn = 1f;

    void Awake()
    {
        var rand = Random.Range(0f, 1f);
        if (rand > chanceToSpawn) Destroy(gameObject);
    }


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
        GameManager.OnPowerupCollected?.Invoke();
        GameObject.Destroy(this.gameObject);
    }
}
