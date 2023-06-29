using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Mục tiêu lớp: giúp tank của người chơi thực hiện chức năng nhăt vật phẩm
public class TakeItems : MonoBehaviour
{
    //Lưu trữ hai UI hiển thị thông số của bomb và thông số của bullet
    [SerializeField] private TextMeshProUGUI bombParameter, bulletParameter;
    //Lưu trữ số lượng bomb bé nhất mà người chơi có thể sở hữu
    [SerializeField] private int minBomb = 0;
    //Lưu trữ Script(Component) Quest
    [SerializeField]private Quest questGetKey;
    //Lưu trữ Script(Component) HealCharater
    [SerializeField] private HealCharater healingPlayer;
    //Lưu trữ Script(Component) ReloadAmmo
    [SerializeField]private ReloadAmmo checkAmmoOfPlayer;
    private void Start() {
        //Tìm kiếm vật thể có tên là ChangeBullet và lấy component ReloadAmmo
        checkAmmoOfPlayer = GameObject.Find("ChangeBullet").GetComponent<ReloadAmmo>();
        //Tìm kiếm vật thể có tag là Player và lấy component HealCharater
        healingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealCharater>();
        //Tìm kiếm vật thể có tên là QuestUI và lấy component Quest
        questGetKey = GameObject.Find("QuestUI").GetComponent<Quest>();
    }
    //Láy số lượng bomb mà người chơi có thể sở hữu 
    public int GetBomb()
    {
        return minBomb;
    }
    //Trừ đi số lượng bomb người chơi có thể sở hữu
    public int SubBomb() => minBomb--;
    //Hàm có chức năng thực hiện các sự kiện khi nhặt vật phẩm
    public void pickItem(GameObject item)
    {
        //Nếu vật phẩm có tag là Bomb
        if (item.tag == "Bomb")
        {
            //Tiến hành cộng thêm 1 cho số lượng bomb của người chơi
            minBomb = minBomb + 1;
            //Lưu trữ số lượng bomb trong một string
            string stringtookBombParameter = string.Format("Bombs: {0}", minBomb);
            //Tiến hành sửa đối số lượng bomb trên màn hình hiển thị
            bombParameter.text = stringtookBombParameter;
            //Xoá đi vật phẩm
            Destroy(item);
        }
        //Nếu vật phẩm có tag là Key
        if(item.tag == "Key"){
            //Gọi thuộc tính key của Quest và cộng thêm 1
            questGetKey.key++;
            //Xoá đi vật phẩm
            Destroy(item);
        }
        //Nếu vật phẩm có tag là Heal
        if(item.tag == "Heal" && healingPlayer.GetcurHealth() < healingPlayer.GetMaxHealth()){
            //Gọi hàm GetcurHealthHealing của HealCharater
            healingPlayer.GetcurHealthHealing();
            //Xoá đi vật phẩm
            Destroy(item);
        }
        //Nếu vật phẩm có tag là BulletItem
        if(item.tag == "BulletItem"){
            //Kiểm tra xem số lượng đan trong khay có bé hơn 100 không nếu có thì
            if(checkAmmoOfPlayer.GetMaxAmmoInCase() < 100){
                //Gọi hàm AdditionalAmmo của ReloadAmmo
                checkAmmoOfPlayer.AdditionalAmmo();
                //Gọi hàm updateParameterOfBullet của ReloadAmmo
                checkAmmoOfPlayer.updateParameterOfBullet();
                //Xoá đi vật phẩm
                Destroy(item);
            }
            //Nếu không đúng thì in ra Log
            else Debug.Log("Không cộng được");
        
        }
    }
}
