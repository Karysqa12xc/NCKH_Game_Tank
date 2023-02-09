using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealCharater : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealBar healBar;
    [SerializeField] private GameScore updateScoreTotal;
    private int curHealth;

    public int GetHealth()
    {
        return maxHealth;
    }
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamge(int dmg)
    {
        curHealth -= dmg;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
    }
    public void EnemyDie()
    {
        if (curHealth == 0)
        {
            Destroy(gameObject);
            updateScoreTotal.updateScore(maxHealth);
        }
    }
    public bool checkEnemiesDie(){
        if(curHealth == 0) return true;
        return false;
    }

}
