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
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamge(int dmg)
    {
        curHealth -= dmg;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
        if (curHealth == 0)
        {
            Destroy(gameObject);
            updateScoreTotal.updateScore(maxHealth);   
        }
    }
}
