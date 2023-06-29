using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu lớp: thực hiện chức năng bắt các sự kiện ấn nút W,A,S,D, các phím mũi tên và vị trí của chuột
public class Tank_Inputs : MonoBehaviour
{
    [Header("Input Properties")]
    //Lưu trữ Camera của màn chơi
    [SerializeField]private Camera Cam;
    //Lưu trữ toạ độ của của crosshair
    [SerializeField]private Vector3 crosshairPosition;
    //Lấy giá trị vị trí của Crosshair
    public Vector3 CrosshairPosition
    {
        get { return crosshairPosition;}
    }
    //Lưu trữ tạo độ crossHair ở tạo độ thường của người chơi
    private Vector3 crosshairNormal;
    //Lấy giá trị của crossHair ở tạo độ thường
    public Vector3 CrosshairNormal
    {
        get { return crosshairNormal; }
    }
    //Lưu trữ giá trị khi bấm W, S hoặc mũi tên lên xuống
    private float forwardInput;
    //Lấy gái trị của forwardInput
    public float ForwardInput
    {
        get { return forwardInput; }
    }
    //Lưu trữ giá trị khi bấm A, D hoặc mũi tên trái phải
    private float rotationInput;
    //Lấy giá trị của rotationInput
    public float RotationInput
    {
        get { return rotationInput; }
    }
    
    void Update()
    {
        //Kiểm tra xem Script này có được gắn Camera không 
        if (Cam)
        {
            HandleInputs();
        }
    }
    //Hàm bắt các sự kiện bấm nút A, W, S, D mũi tên và vị trí của mouse
    protected virtual void HandleInputs()
    {
        //Trả về tia từ camera đến vị trí của con trỏ chuột
        Ray screenRay = Cam.ScreenPointToRay(Input.mousePosition);
        //Lưu trữ va chạm của tia từ camera đến vị trí của con trỏ chuột
        RaycastHit hit;
        //Kiểm tra xem tia từ camera đến vị trí trỏ chuột xem có va chạm với vật thể nào không \
        //và trả về kết quả va chạm cụ thể là hit
        if (Physics.Raycast(screenRay, out hit))
        {
            //Gán giá trị vị trí của điểm va chạm vào biến crosshairPosition
            crosshairPosition = hit.point;
            //Gán giá trị góc xoay của điểm va trạm vào biến crosshairNormal
            crosshairNormal = hit.normal;
        }
        //Lấy giá trị các nút bấm theo hướng thẳng
        forwardInput = Input.GetAxis("Vertical");
        //Lấy giá trị các nút bấm theo hướng ngang
        rotationInput = Input.GetAxis("Horizontal");
    }
}
