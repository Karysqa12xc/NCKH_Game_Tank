using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColiderOfTank : MonoBehaviour
{
    [SerializeField]private TakeItems pickItems;
    [SerializeField]private HealCharater healOfPlayer;
    [SerializeField] private GameObject turnOnGameOverScrenn, turnOnNextLevelScrenn;
    public int levelToUnlock;
    int numberOfUnlockeLevels;
    private void Start() 
    {
        healOfPlayer = GetComponent<HealCharater>();
    }
    private void OnTriggerEnter(Collider other) 
    {  
        if(other.gameObject.tag == "Bomb") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "Key") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "Heal") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "BulletItem") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "BulletEnenmy"){
            healOfPlayer.TakeDamge(1);
            healOfPlayer.DiePlayer(turnOnGameOverScrenn);   
        }
        if(other.gameObject.tag == "Water"){
            healOfPlayer.TakeDamge(20);
            healOfPlayer.DiePlayer(turnOnGameOverScrenn);
        }
        if(other.gameObject.tag == "NextLevel"){
            turnOnNextLevelScrenn.SetActive(true);
            gameObject.SetActive(false);
            numberOfUnlockeLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if(numberOfUnlockeLevels <= levelToUnlock){
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockeLevels + 1);
            }
        }
    }
  
}
