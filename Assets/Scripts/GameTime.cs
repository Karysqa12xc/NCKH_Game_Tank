using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Mục tiêu lớp: Đếm thời gian mà trong game
public class GameTime : MonoBehaviour
{
    //Lưu giữ UI text trong game dùng để hiển thị trên màn hình tương tác với người chơi
    [SerializeField]private TextMeshProUGUI gameTimerText;
    //Biến thời gian
    private float gameTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        //Cho biến thời gian cộng với thời gian chạy mỗi frame khi khởi động trò chơi
        gameTimer += Time.deltaTime;
        //Thực hiện tính toán để lữu giữ giây
        int seconds = (int)(gameTimer % 60);
        //Thực hiện tính toán để lữu giữ phút
        int minutes = (int)(gameTimer / 60) % 60;
        //Thực hiện tính toán để lữu giữ giờ
        int hours = (int)(gameTimer / 3600) % 24;
        //Lưu biến thời gian vào một chuỗi string
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        //Tiến hành thay đổi trong game theo thời gian thực
        gameTimerText.text = timeString;
    }
}
