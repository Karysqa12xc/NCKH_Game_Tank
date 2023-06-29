using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Mục tiêu lớp: thực hiện chức năng mở khoá màn chơi
public class LevelUnlockedHandler : MonoBehaviour
{
    //Lưu trữ những nút bấm của màn chơi
    [SerializeField] Button[] levelBtn;
    //Số lượng màn chơi cần unlock
    int unlokcedLevelNumber;
    private void Start()
    {
        //Kiểm xem trong biến được lưu ở máy cục bộ có key tên là levelsUnlocked 
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            //Nếu không có thì đặt cho giá trị levelsUnlocked bằng 1
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
        //Lấy giá trị màn chơi đã được mở khoá
        unlokcedLevelNumber = PlayerPrefs.GetInt("levelsUnlocked");
        //Chạy vòng lặp quét hết tất cả các nút bấm
        for(int i = 0; i < levelBtn.Length; i++){
            //Chạy vòng lặp và kiểm tra xem màn chơi nào chưa được mở khoá thì tắt chế độ có thể tương tác được cho nút bấm
            levelBtn[i].interactable = false;
        }
    }
    private void Update()
    {
        //Lấy giá trị các màn chơi đã được mở khoá
        unlokcedLevelNumber = PlayerPrefs.GetInt("levelsUnlocked");
        //Chạy vòng lặp và kiểm tra xem màn chơi nào đã được mở khoá thì bật chế độ có thể tương tác được cho nút bấm
        for(int i = 0; i < unlokcedLevelNumber; i++){
            levelBtn[i].interactable = true;
        }
    }
}
