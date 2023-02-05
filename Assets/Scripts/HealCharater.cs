using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealCharater : MonoBehaviour
{
    [SerializeField]private int maxHealth;
    [SerializeField]private HealBar healBar; 
    private int curHealth;
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamge(int dmg)
    {
        curHealth -= dmg;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
        if(curHealth == 0){
            Destroy(gameObject);
        }
    }
    public bool isDestroyedEnemies(bool check = false){
        if(curHealth == 0) return check = true;
        return check;
    }
}
