using UnityEngine;

public class AdaptiveBGM : MonoBehaviour
{
    [SerializeField] string parameterName;
    [Range(0f, 1f)]
    [SerializeField] float value;
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    [SerializeField] float distanceToFreeze = 5f;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameManager gm;
    [SerializeField] GameObject deathMusicPlayer;

    void Update()
    {
        var distance = playerTransform.position.y - GameManager.Snow.transform.position.y;
        value = 1 - Mathf.Min(distance / distanceToFreeze, 1f);
        emitter.SetParameter(parameterName, value);

        if (gm.IsGameOver)
        {
            gameObject.SetActive(false);
            deathMusicPlayer.SetActive(true);
        }
    }


}
