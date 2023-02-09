using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletAndItemDrop : MonoBehaviour
{
    private DropItem Drop;
    private GameObject[] checkEnemiesDie;
    private HealCharater healthList;
    private void Start()
    {
        Drop = GetComponent<DropItem>();
        checkEnemiesDie = GameObject.FindGameObjectsWithTag("Checkpoint_2");
        foreach(var check in checkEnemiesDie){
            healthList = check.GetComponent<HealCharater>();        
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        foreach(var check in checkEnemiesDie){
            if (other.gameObject.tag == "Checkpoint_2" && healthList.checkEnemiesDie())
            {
                var bombdrop = string.Join("", Drop.OnlyGetBomb(Drop.GetItems()));
                Drop.Dropitems(bombdrop);
            }  
        }
        Destroy(gameObject);
    }
}
