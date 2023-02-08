using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletAndItemDrop : MonoBehaviour
{
    private DropItem Drop;
    private void Start() {
        Drop = GetComponent<DropItem>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Checkpoint_2")
        {
            var bombdrop = string.Join("",Drop.OnlyGetBomb(Drop.GetItems()));
            Drop.Drop(bombdrop);
        }
        Destroy(gameObject);
    }
}
