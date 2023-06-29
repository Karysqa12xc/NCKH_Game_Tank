using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Mục tiêu lớp được dùng để cập nhật máu cho các charater trong game
public class HealBar : MonoBehaviour
{
    //Lưu giữ hình ảnh của thanh máu
    [SerializeField]private Image healthbar;
    //Hàm cập nhật hình ảnh
    public void UpdateHealth(float maxHealth , float curentHealth){
        //Thay đổi hình ảnh thanh máu bằng với số lượng máu hiện hành chia cho số lượng máu tối đa 
        healthbar.fillAmount = curentHealth / maxHealth;
    }
}
