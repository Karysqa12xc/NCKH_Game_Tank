using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: Tạo vùng nổ
public class Explosion : MonoBehaviour
{
    //Lưu trữ số lượng điểm
    public int pointsCount;
    //Lưu trữ bán kính lớn nhất của bomb
    public float maxRadius;
    //Tốc độ nổ
    public int speed;
    //Lưu trũ chiều dài của vùng nổ
    public float startWidth;
    //Lưu trữ lực đẩy khi tank địch bị dính phải bomb
    public float force;
    //Lưu trữ nhiều điểm được nối với nhau trong không gian 3D
    private LineRenderer lineRenderer;
    //Lưu trữ âm thanh bom nổ
    [SerializeField] private AudioClip bombAduioClip;
    //Lưu trữ component AudioSource
    [SerializeField] private AudioSource bombAduioSource;
    //Hàm chạy trước hàm Start
    private void Awake()
    {
        //Liên kết với component LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        //Cho số điểm mặc định của lineRenderer mặc định là bằng 1
        lineRenderer.positionCount = pointsCount + 1;
    }
    //Hàm huỷ đi bomb khi được đặt ra
    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
    //Hàm va chạm vật thể xuyên thấu
    private void OnTriggerEnter(Collider other)
    {
        //Thực hiện hàm Blast trải dài trên số khung hình được chỉ định
        StartCoroutine(Blast());
    }
    private void Update()
    {
        //Thực hiện hàm huỷ bom(DestroyBomb) sau 0.4 giây
        Invoke("DestroyBomb", .4f);
    }
    //Hàm thực thiện tạo vụ nổ và sát thưởng của vụ nổ(được thực hiện chậm hơn các hàm khác)
    private IEnumerator Blast()
    {
        //Bán kính vòng tròn  hiện tại
        float currentRadius = 0f;
        //Nếu bán kính vòng tròn hiện tại bé hơn bán kính lớn nhất của vòng tròn
        while (currentRadius < maxRadius)
        {
            //Cho vòng tròn tăng dần theo thời gian khung hình với tốc độ xảy ra của vụ nổ
            currentRadius += Time.deltaTime * speed;
            //Gọi hàm Draw
            Draw(currentRadius);
            //Gọi hàm DameBomb
            DameBomb(currentRadius);
            //Không làm gì cả
            yield return null;
        }
    }
    //Tạo sát thương cho các tank địch ở trong vùng bán kính của vụ nổ
    private void DameBomb(float currentRadius)
    {
        //Các object có colider được quét dựa trên ví trí của vụ nổ đến bán kính vụ nổ 
        Collider[] hittingObjects = Physics.OverlapSphere(transform.position, currentRadius);
        //Chạy vòng lắp quét tất cả các vật thể mà vụ nộ quét được
        for (int i = 0; i < hittingObjects.Length; i++)
        {
            //Lấy componet Rigidbody của các vật thể quét được 
            Rigidbody rb = hittingObjects[i].GetComponent<Rigidbody>();
            //Lấy componet HealCharater của các vật thể quét được 
            HealCharater heal = hittingObjects[i].GetComponent<HealCharater>();
            //Nếu vật thể đó có tag là CheckPoint hoặc tag là Enemy thì
            if (hittingObjects[i].gameObject.tag == "CheckPoint" || hittingObjects[i].gameObject.tag == "Enemy")
            {
                //Chạy một lần âm thanh bomb nổ
                bombAduioSource.PlayOneShot(bombAduioClip);
                /*
                    Trả về giá trị vị trí của vật thể trong vùng bonb nổ trừ vị trí của vật thể được gắn Script này 
                    và chuẩn hoá nó về 1 bằng thuộc tính normalized
                */
                Vector3 direction = (hittingObjects[i].transform.position - transform.position).normalized;
                /*
                    Thêm lực đẩy vào các rb của tank địch bằng với vị trí sau khi chuẩn hoá nhân với lực đẩy
                    với cách thức là Impulse(lực tức thời)
                */
                rb.AddForce(direction * force, ForceMode.Impulse);
                //Gọi hàm TakeDamge của HealCharater
                heal.TakeDamge(1);
                //Gọi hàm DieEnemy của HealCharater
                heal.DieEnemy();
                //Gọi hàm DropItemWhenEnemiesDie của HealCharater
                heal.DropItemWhenEnemiesDie();
            }
        }
    }
    //Hàm có chức nâng vẽ một hình tròn vụ nổ mà người chơi có thể nhìn thấy
    private void Draw(float currentRadius)
    {
        //Lưu trữ các góc giữa các điểm trên đường tròn
        float angleBetweenPoint = 360f / pointsCount;
        //Lặp qua mỗi điểm trên đường tròn
        for (int i = 0; i <= pointsCount; i++)
        {
            //tính góc của điểm hiện tại
            float angle = i * angleBetweenPoint * Mathf.Deg2Rad;
            // tính hướng từ góc hiện tại
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            // tính vị trí của điểm hiện tại
            Vector3 position = direction * currentRadius;
            //đặt vị trí cả các điểm trên vào lineRenderer để tạo thành các điểm nối tạo thành hình tròn
            lineRenderer.SetPosition(i, position);
        }
        //Đặt tốc độ nở của của vụ nổ tủ điểm 0 đến điểm startWidth
        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);
    }
}
