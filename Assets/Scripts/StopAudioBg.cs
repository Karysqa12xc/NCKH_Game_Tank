using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioBg : MonoBehaviour
{
   
    [SerializeField] AudioClip stopAudioClip;
    [SerializeField] AudioSource stopAudioSource;

    private void OnEnable() {
        stopAudioSource.PlayOneShot(stopAudioClip);        
    }
    
    
}
