using UnityEngine;

public class Bus : MonoBehaviour
{
    FMOD.Studio.Bus bus;
    [SerializeField] string busPath = "bus:/MusicBus";

    [Range(-80f, 10f)]
    public float defaultBusVolume = -35;

    [HideInInspector]
    public float busVolume;
    private float volume;

    void Start()
    {
        bus = FMODUnity.RuntimeManager.GetBus(busPath);
        SetBusVolume(defaultBusVolume);
    }

    public void SetBusVolume(float busVolume)
    {
        this.busVolume = busVolume;
        volume = Mathf.Pow(10.0f, busVolume / 20f);
        bus.setVolume(volume);
    }
}