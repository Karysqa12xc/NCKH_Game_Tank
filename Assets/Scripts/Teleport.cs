using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu lớp: thực hiện skill teleport của nhân vật
public class Teleport : MonoBehaviour
{
    //Khai báo một biến vecter 3 lưu trữ giá trị của con trỏ chuột
    Vector3 posittionOfMouse;
    //Lưu trữ Script(component) Tank_Inputs 
    [SerializeField] Tank_Inputs getPositionTeleport;
    private void Start()
    {
        //Liên kết giá trị Tank_Inputs của Player
        getPositionTeleport = GetComponent<Tank_Inputs>();
    }
    //Hàm chạy trươc hàm Update
    private void FixedUpdate()
    {
        //Nếu người chơi bấm chuột phải
        if (Input.GetMouseButtonDown(1))
        {
            //Gọi hàm PlayerTeleport
            PlayerTeleport();
        }
    }
    //Thực hiên Skill teleport
    private void PlayerTeleport()
    {
        //Cho giá tri posittionOfMouse bằng với giá trị của thuộc tính CrosshairPosition của Script Tank_Inputs
        posittionOfMouse = getPositionTeleport.CrosshairPosition;
        //Gán vị trí của vật thể được gắn Script này bằng với vị trị posittionOfMouse
        gameObject.transform.position = posittionOfMouse;
    }
}
