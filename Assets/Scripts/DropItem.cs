using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private List<string> _items = new List<string> { "Key", "Bomb", "Heart", "Bullet" };
    [SerializeField] private GameObject[] itemElement;
    public List<string> GetItems()
    {
        return _items;
    }
    public List<T> GetRandomItem<T>(List<T> itemInput, int count)
    {
        List<T> itemOutput = new List<T>();
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(1, itemInput.Count);
            itemOutput.Add(itemInput[index]);
        }
        return itemOutput;
    }
    public List<T> OnlyGetBomb<T>(List<T> GetBomb)
    {
        List<T> getItem = new List<T>();
        getItem.Add(GetBomb[1]);
        return getItem;
    }
    public List<T> OnlyGetKey<T>(List<T> GetKey){
        List<T> getItem = new List<T>();
        getItem.Add(GetKey[0]);
        return getItem;

    }
    public void Dropitems(string itemName)
    {
        if (itemName.Equals("Key")) Instantiate(itemElement[0], transform.position, transform.rotation);
        if (itemName.Equals("Bomb")) Instantiate(itemElement[1], transform.position, transform.rotation);
        if (itemName.Equals("Heart")) Instantiate(itemElement[2], transform.position, transform.rotation);
        if (itemName.Equals("Bullet")) Instantiate(itemElement[3], transform.position, transform.rotation);
    }
}
