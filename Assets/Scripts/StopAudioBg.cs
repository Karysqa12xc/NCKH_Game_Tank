using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: Tắt âm thanh back ground của trò chơi
public class StopAudioBg : MonoBehaviour
{
    //Lưu trữ âm thanh back ground
    [SerializeField] AudioClip stopAudioClip;
    //Lưu trữ component AudioSource
    [SerializeField] AudioSource stopAudioSource;
    //Hàm được viết sẵn của unity thực hiện sự kiện khi vật thể được gắn scipt này được hiện lên
    private void OnEnable() {
        //Chạy một lần stopAudioClip
        stopAudioSource.PlayOneShot(stopAudioClip);        
    }
    
    
}
