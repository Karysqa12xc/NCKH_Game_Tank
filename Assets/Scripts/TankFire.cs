using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu lớp: thực hiện chức năng bắn của tank người chơi
public class TankFire : MonoBehaviour
{
    //Bản mẫu đạn của người chơi
    public GameObject Shell;
    //Biến tạm lưu trữ cảc bản mẫu được sinh ra
    private GameObject rbShell;
    //Tốc độ của đạn
    public float speedBullet = 10;
    //Vị trí sinh ra bản mẫu
    public Transform FireStart;
    //Lưu trữ component AudioSource
    [SerializeField]private AudioSource fireAudio;
    //Lưu trữ âm thanh khi bắn đạn
    [SerializeField]private AudioClip fireClip;
    public void Update()
    {  
        //Nếu người chơi bấm chuột trái thì
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Chạy âm thanh bắn đạn một lần
            fireAudio.PlayOneShot(fireClip);
            //Sinh ra bản mẫu ở vị trí sinh ra bản mẫu và gán giá trị vào rbShell
            rbShell = Instantiate(Shell, FireStart.position, FireStart.rotation);
            //Tạo vận tốc cho viên đạn khi được bắn ra khỏi nòng
            rbShell.GetComponent<Rigidbody>().velocity = FireStart.forward * speedBullet;
        }
        //Xoá đi viên đạn sau 1 giây
        Destroy(rbShell, 1f);
    }
}