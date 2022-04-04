using UnityEngine;

public class AdaptiveBGM : MonoBehaviour
{
    [SerializeField] string parameterName;
    [Range(0f, 1f)]
    [SerializeField] float value;
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    [SerializeField] float distanceToFreeze = 5f;
    [SerializeField] Transform playerTransform;

    void Update()
    {
        var distance = playerTransform.position.y - GameManager.Snow.transform.position.y;
        value = 1 - Mathf.Clamp(distance / distanceToFreeze, 0f, 1f);
        emitter.SetParameter(parameterName, value);
    }


}
