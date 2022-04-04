using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSpeedChanger : MonoBehaviour
{
    [SerializeField] ParticleSystem emitter;
    ParticleSystem.Particle[] particles;

    [SerializeField] float defaultSpeed = -0.5f;
    [SerializeField] float targetSpeed = -3f;

    [SerializeField] float defaultEmission = 3f;
    [SerializeField] float targetEmission = 6f;
    [SerializeField] float duration = 2f;

    void Start()
    {
        GameManager.OnPowerupCollected += TempSpeedUp;
        // Invoke("TempSpeedUp", 3f);
    }

    void OnDestroy()
    {
        GameManager.OnPowerupCollected -= TempSpeedUp;
    }

    void TempSpeedUp()
    {
        var vol = emitter.velocityOverLifetime;
        var emission = emitter.emission;
        DOTween.To((s) => { vol.y = s; }, targetSpeed, defaultSpeed, duration);
        DOTween.To((e) => { emission.rateOverTime = e; }, targetEmission, defaultEmission, duration);
    }
}