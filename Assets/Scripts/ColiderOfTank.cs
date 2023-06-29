using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Lớp xử lý va chạm của xe tank mà người chơi điều khiển
public class ColiderOfTank : MonoBehaviour
{
    //Lưu trữ Script TakeItems
    [SerializeField]private TakeItems pickItems;
    //Lưu giữ Script HealCharater
    [SerializeField]private HealCharater healOfPlayer;
    //Lưu giữ màn hình hiển thỉ khi thua và khi người chơi qua màn
    [SerializeField] private GameObject turnOnGameOverScrenn, turnOnNextLevelScrenn;
    //lưu giữ số lượng lượng level có thể mở khoá
    public int levelToUnlock;
    //Lưu giữ số hiêu của level khi người chơi đã qua màn
    int numberOfUnlockeLevels;
    private void Start() 
    {
        //Liên kết healOfPlayer với Script(Component) HealCharater
        healOfPlayer = GetComponent<HealCharater>();
    }
    /// <summary>
    ///Xử lý va chạm đối với vật thể có thể đi xuyên qua được trong trò chơi
    /// Yêu cầu để sư dụng hàm này là một trong hai vật thể phải có cả Rigibody và Collider và một collider
    /// phải được đặt mà isTrigger=True(xuyên qua được)
    /// </summary>
    private void OnTriggerEnter(Collider other) 
    {  
        //Nếu tank của ngươi chơi va chạm với vật thể có gắn tag là Bomb thì gọi hàm pickItem của Script TakeItems
        if(other.gameObject.tag == "Bomb") pickItems.pickItem(other.gameObject);
        //Nếu tank của ngươi chơi va chạm với vật thể có gắn tag là Key thì gọi hàm pickItem của Script TakeItems
        if(other.gameObject.tag == "Key") pickItems.pickItem(other.gameObject);
        //Nếu tank của ngươi chơi va chạm với vật thể có gắn tag là Heal thì gọi hàm pickItem của Script TakeItems
        if(other.gameObject.tag == "Heal") pickItems.pickItem(other.gameObject);
        //Nếu tank của ngươi chơi va chạm với vật thể có gắn tag là BulletItem thì gọi hàm pickItem của Script TakeItems
        if(other.gameObject.tag == "BulletItem") pickItems.pickItem(other.gameObject);
        //Nếu tank của người chơi va chạm với vật thể có gắn tag là BulletEnenmy
        if(other.gameObject.tag == "BulletEnenmy"){
            //Gọi hàm TakeDamge của HealCharater
            healOfPlayer.TakeDamge(1);
            //Gọi hàm DiePlayer của HealCharater
            healOfPlayer.DiePlayer(turnOnGameOverScrenn);   
        }
        //Nếu tank của người chơi va chạm với vật thể có gắn tag là Water
        if(other.gameObject.tag == "Water"){
            //Gọi hàm TakeDamge của HealCharater
            healOfPlayer.TakeDamge(20);
            //Gọi hàm DiePlayer của HealCharater
            healOfPlayer.DiePlayer(turnOnGameOverScrenn);
        }
        //Nếu tank của người chơi va chạm với vật thể có gắn tag là NextLevel
        if(other.gameObject.tag == "NextLevel"){
            //Bật màn hình thông báo qua màn
            turnOnNextLevelScrenn.SetActive(true);
            //Ẩn đi tank của người chơi
            gameObject.SetActive(false);
            //Lấy giá trị đã được lưu trên máy của người chơi
            numberOfUnlockeLevels = PlayerPrefs.GetInt("levelsUnlocked");
            //Kiểm tra nếu giá trị numberOfUnlockeLevels bé hơn hoặc bằng giá trị levelToUnlock
            if(numberOfUnlockeLevels <= levelToUnlock){
                //Mở màn chơi tiếp theo
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockeLevels + 1);
            }
        }
    }
  
}
