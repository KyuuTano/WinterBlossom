using UnityEngine;

public class Bus : MonoBehaviour
{
    FMOD.Studio.Bus bus;
    [SerializeField] string busPath = "bus:/MusicBus";

    [Range(-80f, 10f)]
    public float busVolume;
    private float volume;

    void Awake()
    {
        bus = FMODUnity.RuntimeManager.GetBus(busPath);
    }

    void Update()
    {
        volume = Mathf.Pow(10.0f, busVolume / 20f);
        bus.setVolume(volume);
    }

    public void SetBusVolume(float busVolume)
    {
        this.busVolume = busVolume;
    }
}