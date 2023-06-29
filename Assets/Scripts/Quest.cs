using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Mục tiêu lớp: Tạo và quản lý nhiệm vụ mà người chơi cần phải hoàn thành để qua được mà chơi tiếp theo
public class Quest : MonoBehaviour
{
    //Lưu giữ hình ảnh tích xanh của mỗi nhiệm vụ
    //0: Kill all enemy
    //1: Get a key
    public Image[] completedQuestImage;
    //Lưu giữ những vật thể Enemy
    public GameObject[] Enemies;
    /// <summary>
    /// Lưu giữ các vật thể:
    /// finishedGameObstacle: Chướng ngại vật cần phải chạm vào để chuyển màn'
    /// PointDirection: Mũi tên chỉ hướng dẫn luôn chỉ đến finishedGameObstacle
    /// (chỉ hiện khi người chơi ăn được item Key)
    /// blockLevel: chướng ngại vật cản cho người chơi không qua được màn
    /// </summary>
    public GameObject finishedGameObstacle, PointDirection, blockLevel;
    //Lưu giữ số lượng địch và số lượng key người chơi nhặt được
    public int countEnemy = 0, key = 0;
    //Màu sắc nếu người chơi hoàn thành nhiệm vụ
    public Color completedQuest;
    //Lưu giữ giá trị kiểm tra người chơi đã nhặt key chưa và đã tiêu diệt hết địch chưa
    public bool isGetKey, isKillAllEnemy;
    void Start()
    {
        //Cho PointDirection ẩn đi
        PointDirection.SetActive(false);
        //Cho finishedGameObstacle ẩn đi
        finishedGameObstacle.SetActive(false);
        //Gán giá trị màu của completedQuest
        completedQuest = new Color(65, 212, 61);
        //Tìm những vật thể có tag là Enemy và gán vào Enemies
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Chạy vòng lặp dựa trên số lượng Enemy tìm được trên map
        for(int i = 0; i < Enemies.Length; i++){
            //Thực hiện đếm số lượng enemy
            countEnemy++;
        } 
    }
    void Update()
    {
        //Gọi hàm FinishQuest
        FinishQuest();
    }
    //Hàm thực hiện chức năng kiểm tra xem người chơi hoàn thành nhiệm vụ chưa
    void FinishQuest(){
        //Nếu số lượng đich lớn hơn 0 thì
        if(countEnemy > 0){
            //Giá trị kiểm tra số lượng địch isKillAllEnemy = False
            isKillAllEnemy = false;
            //Gán cho hình ảnh của nhiệm vị Kill all enemies là đen
            completedQuestImage[0].color = new Color(0, 0 , 0);
        }
        //Nếu số lượng địch bằng 0 thì
        if(countEnemy == 0){
            //Giá trị kiểm tra số lượng địch isKillAllEnemy = True
            isKillAllEnemy = true;
            //Gán cho hình ảnh của nhiệm vị Kill all enemies là màu sắc khi hoàn thành nhiệm vụ
            completedQuestImage[0].color = completedQuest;
        } 
        //Nếu số lượng key lớn hơn hoặc bằng 1 thì
        if(key >= 1){
            //Giá trị kiểm tra số lượng key isGetKey = True
            isGetKey = true;
            //Gán cho hình ảnh của nhiệm vị Get A Key là màu sắc khi hoàn thành nhiệm vụ
            completedQuestImage[1].color = completedQuest;
        }
        //Nếu cả isGetKey và isKillAllEnemy đều là true thì 
        if(isGetKey && isKillAllEnemy) {
            //Ẩn chướng ngại vật cản trở người chơi qua màn
            blockLevel.SetActive(false);
            //Bật lên chướng ngại vật đích
            finishedGameObstacle.SetActive(true);
            //Bật lên mũi tên chỉ dẫn
            PointDirection.SetActive(true);
        }
    }
}
