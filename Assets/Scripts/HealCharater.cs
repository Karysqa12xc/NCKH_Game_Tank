using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealCharater : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private HealBar healBar;
    [SerializeField] private GameScore updateScoreTotal;
    [SerializeField] private Quest checkOneEnemy;
    [SerializeField] private AudioBehaviour backGroundAudio;
    private DropItem Drop;
    [SerializeField]private float curHealth;
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetcurHealth()
    {
        return curHealth;
    }
    public void GetcurHealthHealing(){
        curHealth++;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
    }

    void Start()
    {
        curHealth = maxHealth;
        Drop = GetComponent<DropItem>();
        checkOneEnemy = GameObject.Find("QuestUI").GetComponent<Quest>();
    }

    public void TakeDamge(float dmg)
    {
        curHealth -= dmg;
        healBar.UpdateHealth((float)maxHealth, (float)curHealth);
    }
    public void DieEnemy()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            updateScoreTotal.updateScore(maxHealth);
        }
    }
    public void DiePlayer(GameObject turnOnGameOverScrenn){
        if(curHealth <= 0){
            turnOnGameOverScrenn.SetActive(true);
            backGroundAudio.enabled = false;
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void DropItemWhenEnemiesDie()
    {
        if (curHealth <= 0 && gameObject.tag == "Checkpoint_2")
        {
            var bombdrop = string.Join("", Drop.OnlyGetBomb(Drop.GetItems()));
            Drop.Dropitems(bombdrop);
        }
        if(curHealth <=0 && checkOneEnemy.countEnemy == 1){
            var KeyDrop = string.Join("", Drop.OnlyGetKey(Drop.GetItems()));
            Drop.Dropitems(KeyDrop);
        }
        if(curHealth <= 0 && gameObject.tag == "Enemy"){
            var itemsDrop = string.Join("", Drop.GetRandomItem(Drop.GetItems(), 1));
            Drop.Dropitems(itemsDrop);
        }
      
    }
}
