using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Mục tiêu lớp dùng để thực hiện các chức năng kiểm tra máu và các sự kiện khi charater hêt máu
public class HealCharater : MonoBehaviour
{
    //Lưu giữ máu tối đa của charater
    [SerializeField] private float maxHealth;
    //Lưu giữ Script HealBar
    [SerializeField] private HealBar healBar;
    //Lưu giữ Script GameScore
    [SerializeField] private GameScore updateScoreTotal;
    //Lưu giữ Script Quest
    [SerializeField] private Quest checkOneEnemy;
    //Lưu giữ Component AudioBehaviour
    [SerializeField] private AudioBehaviour backGroundAudio;
    //Lưu giữ Script DropItem 
    private DropItem Drop;
    // Lưu giữ số lượng máu hiện hành
    [SerializeField]private float curHealth;
    //Hành lấy maxHealth
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    //Hàm lấy curHealth
    public float GetcurHealth()
    {
        return curHealth;
    }
    //Hàm cập nhật máu khi người chơi ăn máu
    public void GetcurHealthHealing(){
        //máu hiện tạy được cộng thêm 1
        curHealth++;
        //Gọi hàm UpdateHealth của HealBar
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
    }

    void Start()
    {
        //Gắn máu hiện hành bằng với lượng máu tối đa
        curHealth = maxHealth;
        //Liên kết với Script(component) DropItem
        Drop = GetComponent<DropItem>();
        //Tìm vật thể có tag là Score và lấy Script(component) GameScore
        updateScoreTotal = GameObject.FindGameObjectWithTag("Score").GetComponent<GameScore>();
        //Tìm vật thể có tên là Score và lấy Script(component) Quest
        checkOneEnemy = GameObject.Find("QuestUI").GetComponent<Quest>();
    }
    //Hàm thay đổi máu của charater khi charater nhận sát thương
    public void TakeDamge(float dmg)
    {
        //Cho máu hiện hành trừ đi số lượng sát thương được chuyền vào
        curHealth -= dmg;
        //Gọi hàm UpdateHealth của HealBar để cập nhập điểm
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
    }
    //Hàm thực hiện khi Enemy chết
    public void DieEnemy()
    {
        //Nếu máu hiện hành của charater(địch) bé hơn hoặc bằng 0 thì
        if (curHealth <= 0)
        {
            //Xoá địch
            Destroy(gameObject);
            //Gọi hàm updateScore của GameScore để cập nhật điểm dựa theo số lượng máu của địch
            updateScoreTotal.updateScore(maxHealth);
        }
    }
    //Hàm thực hiện khi người chơi chết
    public void DiePlayer(GameObject turnOnGameOverScreen){
        //Nếu máu hiện hành của charater(người chơi) bé hơn hoặc bằng 0 thì
        if(curHealth <= 0){
            //Bất pop thông báo người chơi đã thua
            turnOnGameOverScreen.SetActive(true);
            //Tắt âm thanh background của trò chơi
            backGroundAudio.enabled = false;
            //Ẩn người chơi
            gameObject.SetActive(false);
            //Đóng bằng thời gian trò chơi
            Time.timeScale = 0;
        }
    }
    //Hàm thực hiện chức năng rơi vật phẩm khi tiêu diệt địch
    public void DropItemWhenEnemiesDie()
    {
        //Nếu địch có máu bé hơn và bằng 0 và có tag là Checkpoint_2 thì
        if (curHealth <= 0 && gameObject.tag == "Checkpoint_2")
        {
            //Tạo một string để lưu giữ tên của vật phẩm cụ thể là bomb
            var bombdrop = string.Join("", Drop.OnlyGetBomb(Drop.GetItems()));
            //Chuyển tên vật phẩm vào hàm Dropitems của component DropItem
            Drop.Dropitems(bombdrop);
        }
        //Nếu địch có máu bé hơn và số lượng địch trong màn chỉ còn lại một
        if(curHealth <=0 && checkOneEnemy.countEnemy == 1){
            //Tạo một string để lưu giữ tên của vật phẩm cụ thể là Key
            var KeyDrop = string.Join("", Drop.OnlyGetKey(Drop.GetItems()));
            //Chuyển tên vật phẩm vào hàm Dropitems của component DropItem
            Drop.Dropitems(KeyDrop);
        }
        //Nếu địch có máu bé hơn và có tag là Enemy thì
        if(curHealth <= 0 && gameObject.tag == "Enemy"){
            //Tạo string lưu giữ tên vật phẩm ngẫu nhiên
            var itemsDrop = string.Join("", Drop.GetRandomItem(Drop.GetItems(), 1));
            //Chuyển tên vật phẩm vào hàm Dropitems của component DropItem
            Drop.Dropitems(itemsDrop);
        }
      
    }
}
