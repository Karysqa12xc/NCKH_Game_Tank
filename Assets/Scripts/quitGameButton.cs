using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class quitGameButton : MonoBehaviour
{
    [SerializeField] private GameObject displayNotice;


    public void displayNoticeQuit(){
        displayNotice.SetActive(true);
    }
    public void unDisplay()
    {
        displayNotice.SetActive(false);
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("Bạn đã thoát game");
    }
    
}
