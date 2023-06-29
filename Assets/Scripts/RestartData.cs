using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu lớp: Xoá toàn bộ đa ta được lưu ở máy cục bộ
public class RestartData : MonoBehaviour
{
    //Hàm thực hiện chức năng xoá toàn bộ data ở máy cục bộ
    public void RestrartData(){
        PlayerPrefs.DeleteAll();
    }
}
