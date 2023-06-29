using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Mục tiêu lớp: thực hiện hiện chức năng làm lạnh skill của người chơi không cho phép người chơi sử dụng skill liên tục
public class SkillCooldown : MonoBehaviour
{
    //Lưu giữ các hình ảnh của skill
    //0: Skill tốc biến
    //1: Skill đặt bom
    public Image[] imageCooldown;
    //Lưu giữ các Script của tank
    //stopTeleport: Script teleport
    //stopPlanting: Script PlatingBomb
    [SerializeField] private Behaviour stopTeleport, stopPlanting;
    //Thời gian hồi chiêu của tốc biến và đặt bomb
    public float coolDownTele = 15f, coolDownPlan= 10f;
    //Biến kiểm tra skill tốc biên và đặt bomb đã bị cooldown chưa
    bool isCooldownTele, isCoolDownPlan;
    //Lưu giữ Script(Component) TakeItems 
    [SerializeField] private TakeItems quantityBomb;
    //Lưu giữ UI hiên thị chữ trên màn hình dùng để lưu trữ thông số thay đổi của bomb
    [SerializeField] private TextMeshProUGUI changeBombParemeter;
    private void Start() 
    {
        //Tìm vật thể có tên là TankBlueMain và lấy component TakeItems và gán nó vào biến quantityBomb
        quantityBomb = GameObject.Find("TankBlueMain").GetComponent<TakeItems>();
        //Tìm vật thể có tên là TankBlueMain và lấy component Teleport và gán nó vào biến stopTeleport
        stopTeleport = GameObject.Find("TankBlueMain").GetComponent<Teleport>();
        //Tìm vật thể có tên là TankBlueMain và lấy component PlantingBomb và gán nó vào biến stopPlanting
        stopPlanting = GameObject.Find("TankBlueMain").GetComponent<PlantingBomb>();
        //Tìm vật thể có tag là BombText và lấy component TextMeshProUGUI và gán nó vào biến changeBombParemeter
        changeBombParemeter = GameObject.FindGameObjectWithTag("BombText").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        //Gọi hàm CoolDownSkill sau 0.5 giây
        Invoke("CoolDownSkill", 0.5f);
    }
    //Hàm thực hiện chức năng đóng băng skill
    private void CoolDownSkill()
    {
        //Nếu người chơi bấm chuột trái 
        if (Input.GetMouseButtonDown(1))
        {
            //Gán giá trị true cho isCooldownTele
            isCooldownTele = true;
        }
        //Nếu người chơi bấm nút X trên bàn phìm và số lượng bomb ở Script TakeItems bằng 0 
        //và isCoolDownPlan = False thì
        if(Input.GetKeyDown(KeyCode.X) && quantityBomb.GetBomb() > 0 && !isCoolDownPlan)
        {
            //Gán giá trị true cho isCoolDownPlan
            isCoolDownPlan = true;
            //Gọi hàm SubBomb của TakeItems
            quantityBomb.SubBomb();
            //Lưu giá trị thay đổi vào chuỗi stringBombParameter
            string stringBombParameter = string.Format("Bombs: {0}", quantityBomb.GetBomb());
            //Tiến hành thay đổi trên changeBombParemeter
            changeBombParemeter.text = stringBombParameter;
        }
        //Nếu isCoolDownPlan = true thì
        if(isCoolDownPlan){
            //Cho hình ảnh của đặt bomb chạy theo thời gian cooldown là 10 giây
            imageCooldown[1].fillAmount += 1 / coolDownPlan * Time.deltaTime;
            //Tắt đi chức năng đặt bomb của người chơi
            stopPlanting.enabled = false;
            //Nếu thời gian đã chạy hết 10 giây
            if(imageCooldown[1].fillAmount >= 1)
            {
                //Gán lại cho giá trị fill mount của ảnh đặt bomb bằng 0
                imageCooldown[1].fillAmount = 0;
                //Bật lại chức năng đặt bomb của người chơi
                stopPlanting.enabled = true;
                //Gán giá trị false cho isCoolDownPlan
                isCoolDownPlan = false;
            }
        }
        //Nếu isCooldownTele = true thì
        if (isCooldownTele)
        {
            //Cho hình ảnh của tốc biến chạy theo thời gian cooldown là 15 giây
            imageCooldown[0].fillAmount += 1 / coolDownTele * Time.deltaTime;
             //Tắt đi chức năng tốc biến của người chơi
            stopTeleport.enabled = false;   
            //Nếu thời gian đã chạy hết 15 giây
            if (imageCooldown[0].fillAmount >= 1)
            {
                //Gán lại cho giá trị fill mount của ảnh đặt bomb bằng 0
                imageCooldown[0].fillAmount = 0;
                //Bật lại chức năng đặt tốc biến của người chơi
                stopTeleport.enabled = true;
                //Gán giá trị false cho isCooldownTele
                isCooldownTele = false;
            }
        }
    }

}
