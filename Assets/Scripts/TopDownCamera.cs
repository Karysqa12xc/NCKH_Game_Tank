using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu lớp: Tạo Camera theo góc nhìn từ trên xuống
public class TopDownCamera : MonoBehaviour
{
    //Lưu trữ ví trí của tank người chơi
    public Transform m_Target;
    //Lưu trữ chiều cao của Camera
    [SerializeField] private float m_Height = 16f;
    //Lưu trữ khoảng cách của Camera
    [SerializeField] private float m_Distance = 20f;
    //Lưu trữ góc quay của Camera
    [SerializeField] private float m_Angle = 45f;
    //Lưu trữ tốc độ chuyển camera mượt mà
    [SerializeField] private float m_SmoothSpeed = 0.5f;
    //Lưu trữ vận tốc bên ngoài của camera
    private Vector3 refVelocity;
    // Start is called before the first frame update
    void Start()
    {
        //Gọi hàm HandleCamera
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //Gọi hàm HandleCamera
        HandleCamera();
    }
    //Hàm thực hiện các sự kiện Camera
    protected virtual void HandleCamera()
    {
        //Kiểm tra xem có tồn tại mục tiêu tank không 
        if (!m_Target)
        {
            //Nếu không thì không làm gì cả
            return;
        }
        //Tạo vị trí theo trục z của vật thể mà camera quay đến
        Vector3 worldPostion = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
        // Debug.DrawLine(m_Target.position, worldPostion, Color.red);
        //Tạo vị trí theo trục x, y của vật thể mà camera quay đến
        Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPostion;
        // Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

        //Di chuyển camara theo vật thể tank
        //Lưu trữ vị trí cuối cùng bằng với vị trí của tank
        Vector3 flatTargetPosition = m_Target.position;
        //Không cho flatTargetPosition di chuyển theo trục y
        flatTargetPosition.y = 0f;
        //Lưu trữ vị trí cuối cùng bằng với vị trí của tank và cộng thêm giá trị trục x,y của camera
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        //Cho vị trí của vật thể gắn Script này dần dần thay đổi véc-tơ hướng tới mục tiêu mong muốn theo thời gian.
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
        //Cho ví trí của camera hướng về vị trí của player
        transform.LookAt(flatTargetPosition);
    }
}
