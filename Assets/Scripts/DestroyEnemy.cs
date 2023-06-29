using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp là tiêu diệt địch khi địch hết máu
public class DestroyEnemy : MonoBehaviour
{
    //Lưu giữ Script HealCharater
    public HealCharater heal;
    //Lưu giữ Script Quest
    [SerializeField]private Quest questKillEnemy;
    private void Start() {
        //Tìm kiếm game object có tên là QuestUI và lấy Component Quest
        questKillEnemy = GameObject.Find("QuestUI").GetComponent<Quest>();
    }
    /// <summary>
    /// Hàm xử lý va chạm khi tank địch chúng đạn của người chơi
    /// </summary>
    private void OnCollisionEnter(Collision other) 
    {
        //nếu địch va chạm với vật thể có tên tag là Bullet
        if (other.gameObject.tag == "Bullet")
        {
            //Gọi hàm TakeDamge của HealCharater
            heal.TakeDamge(1);
            //Gọi hàm DieEnemy của HealCharater
            heal.DieEnemy();
            //Gọi hàm DropItemWhenEnemiesDie của HealCharater
            heal.DropItemWhenEnemiesDie();
        }
    }
    //Hàm được unity xây dựng được gọi khi vật thể được gắn Script này bị xoá
    private void OnDestroy() {
        //Nếu vật thể được gắn Script này là Enemy thì thuộc tính countEnemy của Script Quest trừ đi 1
        if(gameObject.tag == "Enemy") questKillEnemy.countEnemy--;
    }
    
}
