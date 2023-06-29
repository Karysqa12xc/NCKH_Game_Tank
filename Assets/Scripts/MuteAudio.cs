using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Mục tiêu của lớp: tắt tiếng cục bộ trong game
public class MuteAudio : MonoBehaviour
{
    //Lưu giữ giá trị kiểm tra xem âm thanh đã tắt chưa
    private bool isMuted;

    private void Start()
    {
        //Gán cho giá trị kiểm tra là false
        isMuted = false;
    }
    //Hàm khi bấm nút mute(củ thể là nút âm thanh)
    public void MutePressed()
    {
        //Chuyển giá trị isMuted về thành true
        isMuted = !isMuted;
        //Gán cho thuộc tính pause của AudioListener bằng với giá trị isMuted(true)
        AudioListener.pause = isMuted;
    }
}
