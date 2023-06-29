using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: Huỷ bỏ sụ tồn tại của viên dạn
public class DestroyBullet : MonoBehaviour
{
    //Lưu giữ effect của viên đạn
    [SerializeField]private ParticleSystem Effect;
    //Lưu giữ component transfrom của player
    [SerializeField]private Transform _Player;
    //Lưu giữ khoảng cách của viên đạn đối với người chơi
    float dist;
    //hàm chỉ chạy một lần khì game được bật
    private void Start() {
        //Liên kết Component transfrom của player
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //Hàm được chạy liên tục theo frame khi game chạy
    private void Update() {
        //Nếu vật thể được gắn Script này có tag là Player thì gọi hàm takeCareDistancePlayer
        if(gameObject.tag == "Player") takeCareDistancePlayer();
    }
    //Kiểm tra khoảng cách của người chơi và viên đạn người chơi bắn ra
    private void takeCareDistancePlayer(){
        //Gọi hàm tính toán có sẵn của unity tính toán khoảng cách giữa viên đạn và người chơi
        dist = Vector3.Distance(_Player.position, transform.position);
        //Nêys khoảng cách lớn hơn hoặc bằng 20
        if(dist >= 20){
            //Huỷ đi viên đạn
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Hàm va chạm đối với hai vật thể không xuyên thấu
    /// </summary>
    private void OnCollisionEnter(Collision other)
    {
        //Cho effect chạy khi đạn được bắn ra khỏi nòng
        Effect.Play();
        //Xử lý va chạm giữa tank địch và tank của người chơi mục đích để hai viên đạn có thể chạm vào nhau và không bị xoá đi
        if(other.gameObject.tag != "BulletRed") Destroy(gameObject);
    }
}
