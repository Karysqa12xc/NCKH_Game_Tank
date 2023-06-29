using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Mục tiêu lớp: Thực hiện chức năng tạo skill đặt bomb của player
public class PlantingBomb : MonoBehaviour
{
    //Lưu giữ Script(component) Tank_Inputs
    [SerializeField] private Tank_Inputs posittionOfCrosshair;
    //Tạo biến tạm để lưu giữ ví trí của crossHair của Tank_Inputs
    Vector3 positionCrossHair;
    //Lưu giữ bản mẫu bomb của player
    [SerializeField] private GameObject bombPreabs;
    //Lưu giữ Script(component) Explosion
    [SerializeField] private Explosion ActiveBomb;
    //Lưu giữ Script(component) TakeItems
    [SerializeField] private TakeItems quantityBomb;
    private void Start()
    {
        //Liên kết giá trị với component Tank_Inputs
        posittionOfCrosshair = GetComponent<Tank_Inputs>();
        //Liên kết giá trị với component Explosion
        ActiveBomb = bombPreabs.GetComponent<Explosion>();
    }
    //Hàm thực hiện chức năng đặt bomb
    public void Planting()
    {
        //Nếu người chơi bấm nút X trên bàn phím  và số lượng bomb lớn hơn 0 thì 
        if (Input.GetKeyDown(KeyCode.X) && quantityBomb.GetBomb() > 0)
        {     
            //Gán vị trí của positionCrossHair 
            //bằng thuộc tính CrosshairPosition của Tank_Inputs(lưu giữ vị trí con trỏ chuột)
            positionCrossHair = posittionOfCrosshair.CrosshairPosition;
            //Sinh ra bomb bản mẫu ở vị trí của positionCrossHair và góc xoay của bản mẫu 
            Instantiate(bombPreabs, positionCrossHair, bombPreabs.transform.rotation);
        }
    }
    //Hàm chạy trước hàm Update
    private void FixedUpdate()
    {
        //Gọi hàm Planting
        Planting();
    }

}
