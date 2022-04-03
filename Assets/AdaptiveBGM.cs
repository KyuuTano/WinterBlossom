using UnityEngine;

public class AdaptiveBGM : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float parameter1 = 0;
    [SerializeField] FMODUnity.StudioEventEmitter emitter;

    void Update()
    {
        emitter.SetParameter("Parameter 1", parameter1);
    }
}
