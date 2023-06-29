using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp dùng để làm cho xe có thể trở lại vị trí đứng khi xe bị lật
public class AntiRollOver : MonoBehaviour
{
    //Lưu giữ thông tin về component transfrom của player
    [SerializeField] private Transform _playerRotation;
    //Lưu giữ game object sổ ra cửa số pop hướng dẫn người chơi kích hoạt khả năng của hàm
    [SerializeField] private GameObject instuctAntiRollOver;
    //Hàm chỉ chạy một lần duy nhất khi bắt đầu trò chơi
    private void Start()
    {
        //Liên kết với component transfrom của player
        _playerRotation = GetComponent<Transform>();
    }
    //Hàm chạy theo khung hình trong unity
    void Update()
    {
        //Gọi hàm handleRollOver
        handleRollOver();
        // Debug.Log(_playerRotation.rotation.eulerAngles);
    }
    //Hàm điều chỉnh cho xe không bị lật
    private void handleRollOver()
    {
        //Nếu giá trị rotation của transfrom thuộc vào các giá trị dưới đây thì có nghĩa là xe đã bị lật
        if (
            _playerRotation.rotation.eulerAngles.x == 90 ||
            _playerRotation.rotation.eulerAngles.z == 90 ||
            _playerRotation.rotation.eulerAngles.x == -90 ||
            _playerRotation.rotation.eulerAngles.z == -90 ||
            _playerRotation.rotation.eulerAngles.x == 180 ||
            _playerRotation.rotation.eulerAngles.z == 180 ||
            _playerRotation.rotation.eulerAngles.x == -180 ||
            _playerRotation.rotation.eulerAngles.z == -180 || 
            _playerRotation.rotation.eulerAngles.x == 270 ||
            _playerRotation.rotation.eulerAngles.z == 270 ||
            _playerRotation.rotation.eulerAngles.x == -270 ||
            _playerRotation.rotation.eulerAngles.z == -270
        )
        {
            //Cho pop hướng dẫn được hiển thị
            instuctAntiRollOver.SetActive(true);
            //Nếu người dùng bấm vào nút E trên bàn phím
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Cho pop hướng dẫn ẩn đi
                instuctAntiRollOver.SetActive(false);
                //Đạt lại giá trị rotation của player bằng (0, 0, 0)
                _playerRotation.rotation = Quaternion.identity;
            } 
        }
    }
}
