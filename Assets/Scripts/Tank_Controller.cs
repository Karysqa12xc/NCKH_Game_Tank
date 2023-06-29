using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Backup
// [RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Tank_Inputs))]
//Mục tiêu của lớp: Điều khiển tank của người chơi xoay lòng và điều khiển crossHair
public class Tank_Controller : MonoBehaviour
{
    //Các thuộc tính của di chuyển
    [Header("Movement Properties")]
    //Tốc độ di chuyển của tank
    public float tankSpeed = 15f;
    //Tốc độ rẽ của tank
    public float tankRotationSpeed = 100f;
    //Các thuộc tính của nòng súng
    [Header("Turret Properties")]
    //Vị trí của nòng súng của tank player
    public Transform turretTransfron;
    //Tốc độ xoay lòng
    public float turretLagSpeed = 1.0f;
    //Các thuộc tính của hồng tâm
    [Header("CrossHair Properties")]
    //Vị trí của hồng tâm
    public Transform crossHairTranfrom;
    //Lưu trữ component Rigidbody
    private Rigidbody rb;
    // private CharacterController characterController;
    //Lưu trữ Script Tank_Inputs
    private Tank_Inputs inputs;
    //Vị trí cuối cùng của nòng súng
    private Vector3 finalTurretLookDir;
    //Tốc độ mặc định khi di chuyển về phía trước
    public float acceleration = 1000f;
    //Tốc độ phanh xe mặc định
    public float breakingForce = 600f;
    //Tốc độ quay xe mặc định
    public float maxTurnAngle = 15f;
    [Header("Wheel Controller")]
    //Lưu trữ collider của bánh trước bên phải
    [SerializeField] private WheelCollider frontRight;
    //Lưu trữ collider của bánh trước bên trái
    [SerializeField] private WheelCollider frontLeft;
    //Lưu trữ collider của bánh sau bên phải
    [SerializeField] private WheelCollider backRight;
    //Lưu trữ collider của bánh sau bên trái
    [SerializeField] private WheelCollider backLeft;
    [Header("Wheel Transfrom")]
    //Vị trí của bánh xe bên phải đằng trước
    [SerializeField] Transform frontRightTransfrom;
    //Vị trí của bánh xe bên trái đằng trước
    [SerializeField] Transform frontLeftTransfrom;
    //Vị trí của bánh xe bên phải đằng sau
    [SerializeField] Transform backRightTransfrom;
    //Vị trí của bánh xe bên trái đằng sau
    [SerializeField] Transform backLeftTransfrom;
    //Không sử dụng
    [Header("Audio")]
    [SerializeField] private AudioSource moveSource;
    //Lưu trữ tốc độ di chuyển về phía trước
    private float currentAcceleration = 0f;
    //Lưu trữ tốc độ phanh xe
    private float currentBreakForce = 0f;
    //Lưu trữ tốc độ quay xe
    private float currentTurnAngel = 0f;
    void Start()
    {
        //Liến kết rb với component Rigidbody
        rb = GetComponent<Rigidbody>();
        // characterController = GetComponent<CharacterController>();
        //Liên kết inputs với component Tank_Inputs
        inputs = GetComponent<Tank_Inputs>();
    }
    //Hàm chạy trước Update
    void FixedUpdate()
    {
        // Nếu giá trị của rb và inputs không null thì 
        if (rb && inputs)
        {
            //Gọi hàm HandleMovement
            HandleMovement();
            //Gọi hàm HandleTurret
            HandleTurret();
            //Gọi hàm HandleCrossHair
            HandleCrossHair();
        }
    }
    protected virtual void HandleMovement()
    {
        currentAcceleration = acceleration * inputs.ForwardInput;
        //Nếu người chơi bấm vào nút Space ở trên bàn phím
        if (Input.GetKey(KeyCode.Space)){
            //Gán giá trị làm giảm dần tốc độ của xe
            currentBreakForce = breakingForce;
        }
        else
            //Thả nút Space ra thì dừng xe
            currentBreakForce = 0f;
        //Cho bánh trái đằng trước có tốc độ xoay di chuyển về phía trước bằng với tốc độ di chuyển về phía trước
        frontRight.motorTorque = currentAcceleration;
        //Cho bánh phải đằng trước có tốc độ xoay di chuyển về phía trước bằng với tốc độ di chuyển về phía trước
        frontLeft.motorTorque = currentAcceleration;
        //Gán giá trị của bánh trước bên phải để phanh xe
        frontRight.brakeTorque = currentBreakForce;
        //Gán giá trị của bánh trước bên trái để phanh xe
        frontLeft.brakeTorque = currentBreakForce;
        //Gán giá trị của bánh sau bên phải để phanh xe
        backRight.brakeTorque = currentBreakForce;
        //Gán giá trị của bánh sau bên trái để phanh xe
        backLeft.brakeTorque = currentBreakForce;
        //Cho tốc độ quay xe của tank hướng về hai bên trái phải 
        currentTurnAngel = maxTurnAngle * inputs.RotationInput;
        //Đặt góc quay của bánh trái đằng trước
        frontLeft.steerAngle = currentTurnAngel;
        //Đặt góc quay của bánh phải đằng trước trước
        frontRight.steerAngle = currentTurnAngel;
        //Cập nhật tư thế của bánh xe trước bên trái
        updateWheel(frontLeft, frontLeftTransfrom);
        //Cập nhật tư thế của bánh xe trước bên phải
        updateWheel(frontRight, frontRightTransfrom);
        //Cập nhật tư thế của bánh xe sau bên trái
        updateWheel(backLeft, backLeftTransfrom);
        //Cập nhật tư thế của bánh xe sau bên phải
        updateWheel(backRight, backRightTransfrom);
    }
    //Hàm thực hiện chức năng cập nhật tư thế của bánh xe
    void updateWheel(WheelCollider col, Transform trans)
    {
        //Vị trí của 2 bánh trước và 2 bánh sau
        Vector3 position;
        //Góc quay của hai bánh trước và 2 bánh sau
        Quaternion rotation;
        //Điểu chỉnh vị trí của bánh xe 
        col.GetWorldPose(out position, out rotation);
        //gán vị trí của bánh xe bằng với vị trí của bánh xe được khai báo ở ngoài hàm này
        trans.position = position;
        //gán góc quat của bánh xe bằng với vị trí của bánh xe được khai báo ở ngoài hàm này
        trans.rotation = rotation;
    }
    //Hàm thực hiện chức năng xoay nòng của tank player
    protected virtual void HandleTurret()
    {
        //Kiểm tra xem có tồn tại vị trí của nòng súng không
        if (turretTransfron)
        {
            //Vị trí của được xoay nòng của tank được gán bằng 
            //giá trị của hồng tâm con trỏ chuột trừ đi vị trí của nòng súng
            Vector3 turretLookDir = inputs.CrosshairPosition - turretTransfron.position;
            //Không cho vị chí xoay của nòng súng di chuyển theo trục y
            turretLookDir.y = 0f;
            //Gán vị trí cuối cùng của nòng súng bằng 
            //với vị trí của cuối cùng của nòng hướng đến vị trí turretLookDir di chuyển theo tốc độ của nòng súng
            finalTurretLookDir = Vector3.Lerp(finalTurretLookDir, turretLookDir, turretLagSpeed * Time.deltaTime);
            //Di chuyển góc xoay của turretTransfron hướng đến turretLookDir
            turretTransfron.rotation = Quaternion.LookRotation(turretLookDir);
        }
    }
    //Hàm di chuyển hồng tâm theo con trỏ chuột
    protected virtual void HandleCrossHair()
    {
        //Nếu tồn tại vị trí của hồng tâm thì
        if (crossHairTranfrom)
        {
            //Cho vị trí của hồng tâm bằng vị trí của con trỏ chuột
            crossHairTranfrom.position = inputs.CrosshairPosition;
        }
    }
}
