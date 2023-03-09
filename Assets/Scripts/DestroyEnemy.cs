using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public HealCharater heal;
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            heal.TakeDamge(1);
            heal.DieEnemy();
            heal.DropItemWhenEnemiesDie();
        }
    }
    
}
