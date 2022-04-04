using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCA: MonoBehaviour {
    
  FMOD.Studio.VCA vca;
  
  
  [SerializeField][Range(-80f, 10f)] 
  private float vcaVolume;
  private float volume;
  
  void Start() 
  {
    vca = FMODUnity.RuntimeManager.GetVCA("vca:/Ambient VCA");
  }
  
  void Update() 
  {
    volume = Mathf.Pow(10.0f, vcaVolume / 20f);
    vca.setVolume(volume);
  }
}
