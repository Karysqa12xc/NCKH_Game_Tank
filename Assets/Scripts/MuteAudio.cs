using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MuteAudio : MonoBehaviour
{
    private bool isMuted;

    private void Start()
    {
        isMuted = false;
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
