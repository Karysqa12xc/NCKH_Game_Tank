using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp làm cho tank địch tấn công người chơi
public class HandleTurretEnemy : MonoBehaviour
{
    //Lưu giữ component trasfrom của người chơi
    [SerializeField]Transform _Player;
    //Lưu giữ khoảng cách của người chơi và địch
    float dist;
    //Tốc độ đạn của địch khi được bắn ra khỏi lòng
    [SerializeField]private float speedBullet;
    //Lưu giữ vị trí mà địch không tấn công người chơi nữa
    [SerializeField]private float howClose;
    //Lưu giữ component transfrom của nòng súng và vị trí sinh ra đạn mẫu của địch
    public Transform tower, bulletPreabs;
    //Lưu giữ đạn của địch đạn địch
    public GameObject _projectile;
    //Lưu giữ tỷ lệ đạn được bắn ra theo thời gian 
    public float fireRate, nextFire;
    void Start()
    {
        //Tìm vật thể có tag là Player và lấy component transfrom của nó
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    private void Update() {
        //Gọi hàm TurretCtrl
        TurrertCtrl();
    }
    //Hàm thực hiện chức năng xoay nòng và tìm vị trị của player và tốc độ ra đạn của địch
    public void TurrertCtrl()
    {
        //Tính khoảng cách của player và vật thể được gắn Script này(địch)
        dist = Vector3.Distance(_Player.position, transform.position);
        //Kiểm tra xem khoảng cách giữa địch và player có nhỏ hơn khoảng cách được chỉ định không
        if (dist <= howClose)
        {
            //Cho nòng súng của địch xoay về vị trị của người chơi
            tower.LookAt(_Player);
            //cho vị trí sinh đạn của địch xoay về vị trí của người chơi
            bulletPreabs.LookAt(_Player);
            //Nếu thời gian chay trong từng frame lớn hơn thời gian phát bắn tiếp theo của địch thì
            if(Time.time > nextFire){
                //Cập nhật thời gian bằng với thời gian thực cộng với 1/tỷ lệ viên đạn được bắn ra 
                nextFire = Time.time + 1f / fireRate;
                //Gọi hàm ShootOfEnemy
                ShootOfEnemy();
            }
            
        }
    }
    //Hàm thực hiên chức năng bắn của địch
    public void ShootOfEnemy()
    {
        //Biến tạm lưu giữ viên đạn của địch được sinh ra
        GameObject cloneBulletOfEnemy =  Instantiate(_projectile, bulletPreabs.position, tower.rotation);
        //Thực hiện tính và gán vận tốc đạn của địch khi ra khỏi nòng
        cloneBulletOfEnemy.GetComponent<Rigidbody>().velocity = bulletPreabs.forward * speedBullet;
        //Xoá bỏ viên đạn được bắn ra sau 1 giây
        Destroy(cloneBulletOfEnemy, 1f);
    }
}
