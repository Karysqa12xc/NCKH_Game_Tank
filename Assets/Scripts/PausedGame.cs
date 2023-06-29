using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: bật màn hình thông báo pause game và đóng bằng toàn bộ hoat động trong game
public class PausedGame : MonoBehaviour
{
    //Lưu giữ vật thể pause game và player
    [SerializeField] private GameObject pauseGameScrenn, _player;
    //Giá trị kiểm tra đã pause game chưa
    [SerializeField] private static bool GameIsPaused = false;
    //Lưu giữ Audio backGround của Game
    [SerializeField] private AudioSource stopBackGroudAudio;
    [SerializeField] private Behaviour tankFire;
    private void Start() {
        //Tìm kiếm vật thể có tag là Player và liên kết với vật thể player của Script này
        _player = GameObject.FindGameObjectWithTag("Player");
        tankFire = GameObject.Find("ChangeBullet").GetComponent<ReloadAmmo>();
    }
    void Update()
    {
        //Gọi hàm turnOnScrenn
        turnOnScrenn();
    }

    //Hàm bật màn hình pause game
    private void turnOnScrenn()
    {
        //Nếu người chơi bấm nút Tab trên bàn phìm thì
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Kiểm tra giá trị của GameIsPause nếu nó là true thì
            if (GameIsPaused) 
            {
                //Hiện lên tank của người chơi
                _player.SetActive(true);
                //Cho âm thanh background của trờ chơi được bật
                stopBackGroudAudio.Play();
                //bật chức năng bắn của tank
                tankFire.enabled = true;
                //Gọi hàm Restart
                Restart();
            }
            //Kiểm tra giá trị của GameIsPause nếu nó là false        
            else 
            {   
                //Ẩn đi tank của người chơi
                _player.SetActive(false);
                //Cho âm thanh background của trò chơi tắt đi 
                stopBackGroudAudio.Pause();
                //tắt chức năng bắn của tank
                tankFire.enabled = false;
                //Gọi hàm Pause
                Pause();
            }
        }
    }
    //Hàm thực hiện chức năng ẩn đi màn hình pasue game và bỏ đóng băng thời gian của trò chơi 
    //và gán lại giá trị của GameIsPaused = false
    public void Restart()
    {
        pauseGameScrenn.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    //Hàm thực hiện chức năng hiện lên đi màn hình pasue game và đóng băng thời gian của trò chơi 
    //và gán lại giá trị của GameIsPaused = true
    public void Pause()
    {
        pauseGameScrenn.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    //Hàm thực hiện chức năng bỏ thời gian đóng bằng của game khi bấm vào mọi nút bấm trong game
    public void SetTimeScaleOfBtn(){
        Time.timeScale = 1f;
    }
   

}
