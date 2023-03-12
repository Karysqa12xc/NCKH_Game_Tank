using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColiderOfTank : MonoBehaviour
{
    [SerializeField]private TakeItems pickItems;
    [SerializeField] private HealCharater healOfPlayer;
    [SerializeField] private GameObject turnOnGameOverScrenn, turnOnNextLevelScrenn;
    private void Start() 
    {
        healOfPlayer = GetComponent<HealCharater>();
    }
    private void OnTriggerEnter(Collider other) 
    {  
        if(other.gameObject.tag == "Bomb") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "Key") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "Heal") pickItems.pickItem(other.gameObject);
        if(other.gameObject.tag == "BulletEnenmy"){
            healOfPlayer.TakeDamge(1);
            healOfPlayer.DiePlayer(turnOnGameOverScrenn);   
        }
        if(other.gameObject.tag == "NextLevel"){
            turnOnNextLevelScrenn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
  
}
