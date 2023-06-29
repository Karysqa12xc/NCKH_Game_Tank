using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: tạo một bản đồ thu nhỏ để người cho có thể quan sát map toàn diện hơn
public class Minimap : MonoBehaviour
{
    //Lưu giữ component Transform của tank người hcowi
    public Transform _Player;
    //Được gọi sau hàm Update
    private void LateUpdate() 
    {
        //Cho một biến tạm lưu vị trí của Player
        Vector3 newPosittion = _Player.position;
        //Cho giá trị y bằng với giá trị y của vật thể được gắn Script này
        newPosittion.y = transform.position.y;
        //Cho vị trí của vật thể được gắn giá trị này bằng với giá trị tạm 
        transform.position = newPosittion;
    }
}
