using UnityEngine;

public class DeathBox : MonoBehaviour
{
    [SerializeField] GameManager gm;

    void OnTriggerEnter2D()
    {
        gm.GameOver();
    }
}
