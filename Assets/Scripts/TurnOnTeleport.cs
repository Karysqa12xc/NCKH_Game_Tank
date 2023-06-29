using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Mục tiêu lớp: Bật màn hình hướng dẫn người chơi sử dụng Skill teleport
public class TurnOnTeleport : MonoBehaviour
{
    //Lưu trữ Script Teleport
    [SerializeField] private Behaviour teleportScript;
    //Lưu trữ các vật thể
    //turnOnTeleUI: vật thể lưu trữ màn hình cha của màn hình hướng dẫn teleport
    //howToTeleport : Màn hình hướng dẫn teleport
    //_Player: Vật thể tank của người chơi
    [SerializeField] private GameObject turnOnTeleUI, howToTeleport, _Player;
    //Lưu chữ nút vấm tắt đi turnOnTeleUI
    [SerializeField] private Button turnOffBtn;
    //Kiểm tra số lần va trạm với checkpoint hướng dẫn teleport
    int countTrigger = 0;
    private void Start()
    {
        //Thêm hàm turnOffTeleportTutorial vào sự kiện onclick
        turnOffBtn.onClick.AddListener(turnOffTeleportTutorial);
    }
    //Hàm va chạm xuyên thấu giữa hai vật thể
    private void OnTriggerEnter(Collider other)
    {
        //Nếu vật thể khác vật thể được gắn Script này có tag là Player và số lần va chạm bằng 0 thì
        if (other.gameObject.tag == "Player" && countTrigger == 0)
        {
            //Đóng băng thời gian của game
            Time.timeScale = 0;
            //Tăng thêm số lần vâ trạm 
            countTrigger++;   
            //Ẩn đi tank của người chơi
            _Player.SetActive(false);
            //Bật vật thể cha lưu trữ màn hình hưỡng dẫn teleport
            turnOnTeleUI.SetActive(true);
            //Bật màn hình hưỡng dẫn teleport
            howToTeleport.SetActive(true);
            //Bật chức năng teleport
            teleportScript.enabled = true;
        }
    }
    //Hàm có chức năng tắt đi màn hình hướng dẫn teleport
    public void turnOffTeleportTutorial()
    {
        //Xoá bỏ đóng băng thời gian của game
        Time.timeScale = 1;
        //Hiển thị lại tank của player
        _Player.SetActive(true);
        //Màn hình hướng dẫn teleport bị ẩn đi
        howToTeleport.SetActive(false);
        //Hiển thị vật thể cha của màn hình hướng dẫn teleport
        turnOnTeleUI.SetActive(true);
    }
}
