using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Mục tiêu lớp: thực hiện chức năng hiển thị các màn hình hướng dẫn 
public class Tutorials : MonoBehaviour
{
    //Lữu trữ màn hình thông báo hướng dẫn di chuyển và tank của player
    [SerializeField] private GameObject noticeMoveTutorial, _Player, 
    /// <summary>
    /// noticePlantingTutorial: Màn hình hướng dẫn đặt bomb
    /// fireNoticeTutorial: Màn hình hưỡng dẫn tank bắn súng
    /// checkPoint_2: Điểm hướng dẫn thứ hai
    /// stopTankDes: hướng dẫn dừng tank
    /// plantingUI: planting UI
    /// </summary>
    noticePlantingTutorial, fireNoticeTutorial, checkPoint_2, backgroundDes, plantingUI;
    //Các nút bấm thoát màn hình hướng dẫn
    [SerializeField] private Button[] quitButtonTutorial;
    /// <summary>
    /// moveTankBehavior: Script Tank_Controller
    /// reloadAmmo: Script ReloadAmmo
    /// fireScript: Script TankFire
    /// plantingBombScript: Script PlantingBomb
    /// </summary>
    [SerializeField] private Behaviour moveTankBehavior, reloadAmmo, fireScript, plantingBombScript;
    //Lưu giữ số lần va chạm của các check point
    private int countTrigerTutorial = 0;
    void Start()
    {
        Invoke("turnOnMoveTutorial", 1.5f);
    }
    //Hàm thực hiện chức năng hiển thị màn hình hướng dẫn tank di chuyển
    public void turnOnMoveTutorial()
    {
        //Đóng bằng thời gian trong game
        Time.timeScale = 0;
        //Bật màn hình hướng UI hướng dẫn tank di chuyển
        noticeMoveTutorial.SetActive(true);
        //Tắt đi Script Tank_Controller
        moveTankBehavior.enabled = false;
        //Tắt đi Script ReloadAmmo
        reloadAmmo.enabled = false;
        //Bật hướng dẫn dừng xe và pause game
        backgroundDes.SetActive(true);
    }
    //Hàm va chạm xuyên thấu
    private void OnTriggerEnter(Collider other)
    {
        //Nếu Script được gắn tag Checkpoint_2
        if(gameObject.tag == "Checkpoint_2")
        {
            //Đóng băng thời gian
            Time.timeScale = 0;
            //Bật màn hình hiển thị hướng dẫn bắn tank
            fireNoticeTutorial.SetActive(true);
            //Bật Script TankFire
            fireScript.enabled = true;
            //Ẩn đi tank của người chơi
            _Player.SetActive(false);
            //Tăng thêm giá trị đếm số lần va chạm
            countTrigerTutorial++;
        }
        //Nếu vật thể khác được gắn tag là Player và có số lần countTrigerTutorial = 0
        if (other.gameObject.tag == "Player" && countTrigerTutorial == 0)
        {
            //Đóng băng thời gian
            Time.timeScale = 0;
            //Hiển thị màn hình hướng dẫn đạt bomb
            noticePlantingTutorial.SetActive(true);
            //Ẩn đi tank của người chơi
            _Player.SetActive(false);
            //Bật platingUI
            plantingUI.SetActive(true);
            //Bật Script PlantingBomb
            plantingBombScript.enabled = true;
            
        }
        
    }
    //Tắt đi màn hình hướng dẫn đặt bomb
    public void turnOffPlantingTutorial()
    {
        //Loại bỏ đóng băng thời gian
        Time.timeScale = 1;
        //Hiển thị lại tank của người chơi
        _Player.SetActive(true);
        //Ẩn đi màn hình hướng dẫn đặt bomb
        noticePlantingTutorial.SetActive(false);
        //Xoá đi vật thể gắn Script này
        Destroy(gameObject);
    }
    //Tắt đi màn hình hướng dẫn di chuyển của tank
    public void turnOffMoveTutorial()
    {
        //Loại bỏ đóng băng thời gian
        Time.timeScale = 1;
        //Hiển thị lại tank của người chơi
        _Player.SetActive(true);
        //Ẩn đi màn hình hướng dẫn di chuyển của tank
        noticeMoveTutorial.SetActive(false);
        //Bật lại Script Tank_Controller
        moveTankBehavior.enabled = true;
    }
    //Tắt đi màn hình hướng dẫn bắn đạn của tank người chơi
     public void turnOffFireTutorial()
    {
        //Loại bỏ đóng băng thời gian
        Time.timeScale = 1;
        //Hiển thị lại tank của người chơi 
        _Player.SetActive(true);
        //Ẩn đi màn hình hướng dẫn bắn của tank người chơi
        fireNoticeTutorial.SetActive(false);
        //Bật Script ReloadAmmo
        reloadAmmo.enabled = true;
        //Xoá đi vật thể checkPoint_2
        Destroy(checkPoint_2);
    }
    private void Update()
    {
        //Thêm sự kiện turnOffMoveTutorial cho nút bấm tắt đi màn hình hiển thị hướng dẫn di chuyển
        quitButtonTutorial[0].onClick.AddListener(turnOffMoveTutorial);
        //Thêm sự kiện turnOffFireTutorial cho nút bấm tắt đi màn hình hiển thị hướng dẫn bắn của tank người chơi
        quitButtonTutorial[1].onClick.AddListener(turnOffFireTutorial);
        //Thêm sự kiện turnOffPlantingTutorial cho nút bấm tắt đi màn hình hiển thị hướng dẫn Skill đặt bomb của người chơi
        quitButtonTutorial[2].onClick.AddListener(turnOffPlantingTutorial);
    }
}
