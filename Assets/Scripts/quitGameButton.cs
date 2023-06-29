using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Mục tiêu của lớp: thoát game
public class quitGameButton : MonoBehaviour
{
    //Lưu giữ màn hình hiển thỉ thoát game
    [SerializeField] private GameObject displayNotice;

    //Hàm hiển thị màn hình thoát game
    public void displayNoticeQuit(){
        displayNotice.SetActive(true);
    }
    //Hàm ẩn màn hình thoát game
    public void unDisplay()
    {
        displayNotice.SetActive(false);
    }
    //Hàm thực hiện chức năng thoát game
    public void quitGame(){
        //Gọi Hàm Quit của Application đã được unity xây dựng 
        Application.Quit();
        //Thông báo đã thoát game trên mà hình console
        Debug.Log("Bạn đã thoát game");
    }
    
}
