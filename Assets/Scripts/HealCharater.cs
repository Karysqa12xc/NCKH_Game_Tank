using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCharater : MonoBehaviour
{
    public int maxHealth;
    public HealBar healBar;
    private int curHealth;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        
    }

    public void TakeDamge(int dmg){
        curHealth -= dmg;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
    }

    
}
