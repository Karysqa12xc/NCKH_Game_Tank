using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: tạo ta mũi tên chỉ dẫn người chơi đến đích khi hoàn thành màn chơi
public class DirectionalArrow : MonoBehaviour
{
    //Lưu giữ vật thể được chỉ định là đích
    [SerializeField] private GameObject targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        //Liên kết với vật thể được chỉ định và đích, nếu vật thể đó có tag là NextLevel
        targetPoint = GameObject.FindGameObjectWithTag("NextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        //Tạo một biến tạm để lưu vị trí của vật thể đích
        Vector3 targetPointPosition = targetPoint.transform.position;
        //Cho giá trị tạm y bằng với giá trị y của vật thể được gắn Script(tránh trường hợp vật thể chỉ xuống đất)
        targetPointPosition.y = transform.position.y;
        //Gọi hàm LookAt được unity xây dựng xoay vật thể sao cho vật thể luôn chỉ về vị trí đích
        transform.LookAt(targetPointPosition);
        
    }
}
