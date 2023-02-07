using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    List<string> items = new List<string>{"Bullet", "Bomb", "Heart", "Armor"};

    public List<T> GetRandomItem<T>(List<T> itemInput, int count)
    {
        List<T> itemOutput = new List<T>();
        for(int i = 0; i < count; i++)
        {
            int index = Random.Range(0, itemInput.Count);
            itemOutput.Add(itemInput[index]);
        }
        return itemOutput;
    }
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            var RandomItem = GetRandomItem(items, 1);
            var itemDrop = string.Join(" ", RandomItem);
            if(itemDrop.Equals("Armor"))
            {
                Debug.Log(1);
            }
            if(itemDrop.Equals("Bullet")){
                Debug.Log(2);
            }
            if(itemDrop.Equals("Bomb")){
                Debug.Log(3);
            }
        }
    }
}
