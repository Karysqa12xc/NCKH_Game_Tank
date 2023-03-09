using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColiderOfTank : MonoBehaviour
{
    [SerializeField]private TakeItems pickItems;
    [SerializeField] private HealCharater healOfPlayer;
    [SerializeField] private GameObject turnOnGameOverScrenn;
    private void Start() 
    {
        healOfPlayer = GetComponent<HealCharater>();
    }
    private void OnTriggerEnter(Collider other) 
    {
       
        if(other.gameObject.tag == "Bomb"){
            pickItems.pickItem(other.gameObject);
        }
        if(other.gameObject.tag == "BulletEnenmy"){
            healOfPlayer.TakeDamge(1);
            healOfPlayer.DiePlayer(turnOnGameOverScrenn);
            
        }
    }
  
}
