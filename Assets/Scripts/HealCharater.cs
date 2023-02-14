using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealCharater : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private HealBar healBar;
    [SerializeField] private GameScore updateScoreTotal;
    private DropItem Drop;
    private float curHealth;
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetcurHealth()
    {
        return curHealth;
    }
    void Start()
    {
        curHealth = maxHealth;
        Drop = GetComponent<DropItem>();
    }

    public void TakeDamge(float dmg)
    {
        curHealth -= dmg;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
        
    }
    public void EnemyDie()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            updateScoreTotal.updateScore(maxHealth);
        }
    }
    public void DropItemWhenEnemiesDie()
    {
        if (curHealth <= 0 && gameObject.tag == "Checkpoint_2")
        {
            var bombdrop = string.Join("", Drop.OnlyGetBomb(Drop.GetItems()));
            Drop.Dropitems(bombdrop);
        }
    }
}
