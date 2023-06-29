using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mục tiêu của lớp: chức năng rơi vật phẩm khi tiêu diệt địch
public class DropItem : MonoBehaviour
{
    //Tạo một list lưu giữ tên của các item có trong game
    private List<string> _items = new List<string> { "Key", "Bomb", "Heart", "Bullet" };
    //Tạo vật thể lưu giữ các item trong game
    [SerializeField] private GameObject[] itemElement;
    //Hàm lấy items
    public List<string> GetItems()
    {
        return _items;
    }
    //Hàm lấy ngẫu nhiên item
    public List<T> GetRandomItem<T>(List<T> itemInput, int count)
    {
        //Tạo một List tạm 
        List<T> itemOutput = new List<T>();
        //Chạy một vòng lặp biệu hiện số lượng item ngẫu nhiên sẽ rớt ra 
        for (int i = 0; i < count; i++)
        {
            //Cho index bằng giá trị ngẫu nhiên từ 1 cho đến số lượng item có trong list 
            int index = Random.Range(1, itemInput.Count);
            //Thêm item đó vào list tạm với index được lấy ngẫu nhiên
            itemOutput.Add(itemInput[index]);
        }
        //Trả về giá trị đã được thêm
        return itemOutput;
    }
    //Chỉ lấy item Bomb
    public List<T> OnlyGetBomb<T>(List<T> GetBomb)
    {
        //Tạo list tạm
        List<T> getItem = new List<T>();
        //Vì vị trí của Bomb là 1 nên ta thêm vào getItem với vị trị của list tạm là 1
        getItem.Add(GetBomb[1]);
        //Trả về list tạm
        return getItem;
    }
    //Chỉ lấy item Key
    public List<T> OnlyGetKey<T>(List<T> GetKey){
        //Tạo list tạm
        List<T> getItem = new List<T>();
        //Vì vị trí của Bomb là 0 nên ta thêm vào getItem với vị trị của list tạm là 0
        getItem.Add(GetKey[0]);
        //Trả về list tạm
        return getItem;

    }
    //Tạo vật phẩm ở vị trị địch bị tiêu diệt
    public void Dropitems(string itemName)
    {
        //Nếu tên của item bằng Key thì tạo ra vật phẩm Key trong itemElement với vị trí và góc xoay của địch
        if (itemName.Equals("Key")) Instantiate(itemElement[0], transform.position, transform.rotation);
        //Nếu tên của item bằng Bomb thì tạo ra vật phẩm Bomb trong itemElement với vị trí và góc xoay của địch
        if (itemName.Equals("Bomb")) Instantiate(itemElement[1], transform.position, transform.rotation);
        //Nếu tên của item bằng Heart thì tạo ra vật phẩm Heart trong itemElement với vị trí và góc xoay của địch
        if (itemName.Equals("Heart")) Instantiate(itemElement[2], transform.position, transform.rotation);
        //Nếu tên của item bằng Bullet thì tạo ra vật phẩm Bullet trong itemElement với vị trí và góc xoay của địch
        if (itemName.Equals("Bullet")) Instantiate(itemElement[3], transform.position, transform.rotation);
    }
}
