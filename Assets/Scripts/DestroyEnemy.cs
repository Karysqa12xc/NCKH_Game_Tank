using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public HealCharater heal;
    [SerializeField]private Quest questKillEnemy;
    private void Start() {
        questKillEnemy = GameObject.Find("QuestUI").GetComponent<Quest>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            heal.TakeDamge(1);
            heal.DieEnemy();
            heal.DropItemWhenEnemiesDie();
        }
    }
    private void OnDestroy() {
        if(gameObject.tag == "Enemy") questKillEnemy.countEnemy--;
    }
    
}
