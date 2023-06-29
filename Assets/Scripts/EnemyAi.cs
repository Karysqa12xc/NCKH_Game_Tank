using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Mục tiêu cho địch đi tuần xung quan một vị trí mà địch được đặt
public class EnemyAi : MonoBehaviour
{
    //Lưu giữ component transfrom của vật thể và Enemy sẽ đi theo
    [Header("Use Patrol Emeny AI")]
    [SerializeField] private Transform target;
    //Lưu giữ thành phần điều hướng đường đi của địch
    private NavMeshAgent navMeshAgent;
    //Lưu trữ bán kính vùng mà tank địch sẽ đi tuần
    public float range;
    private void Start()
    {
        //Liên kết với NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Gọi hàm EnemyPatrol
        EnemyPatrol();
    }
    //Hàm thực hiện chức năng đi tuần của địch
    private void EnemyPatrol()
    {
        //Kiểm tra xem ai đã đo đến cuối vị trí chỉ định hay chưa
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) 
        {
            //Tạo một vị trí tạm
            Vector3 point;
            //Kiểm tra vị trị ở điểm mục tiêu có tìm thấy vị trí ngẫu nhiên được sinh ra trong không gian được 
            //chỉ định không 
            if (RandomPoint(target.position, range, out point))
            {
                //Vẽ ra một tia hiển thị nên màn hình 
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                //Di chuyển địch đến vị trí ngẫu nhiên này
                navMeshAgent.SetDestination(point);
            }
        }      
    }
    //Hàm thực hiên chức năng tạo ra vị trí ngẫu nhiên xung quanh vị trí được chỉ định
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        //Tạo ra vị trí ngẫu nhiên xung quanh vị tri mục tiêu trong không gian 3 chiều
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
        //Lưu giữ thông tin của của NavMesh
        NavMeshHit hit;
        //Tìm điểm gần nhất dựa trên NavMesh trong một phạm vi được chỉ định.
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            //Cho toạ độ và tank địch sẽ di chuyển đến bằng với vị trí được sinh ra ngẫu nhiên
            result = hit.position;
            //Trả về giá trị true
            return true;
        }
        //Gán lại giá trị point bên ngoài bằng (0, 0, 0)
        result = Vector3.zero;
        //Trả về giá trị false
        return false;
    }
}

