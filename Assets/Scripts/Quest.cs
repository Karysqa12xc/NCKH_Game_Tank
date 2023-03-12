using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{
    public Image[] completedQuestImage;
    public GameObject[] Enemies;
    public int countEnemy = 0, key = 0;
    public Color completedQuest;
    public bool isGetKey, isKillAllEnemy;
    void Start()
    {
        completedQuest = new Color(65, 212, 61);
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < Enemies.Length; i++){
            countEnemy++;
        } 
    }
    
    void Update()
    {
        FinishQuest();
    }
    void FinishQuest(){
        if(countEnemy == 0){
            isKillAllEnemy = true;
            completedQuestImage[0].color = completedQuest;
        } 
        if(key == 1){
            isGetKey = true;
            completedQuestImage[1].color = completedQuest;
        }
        
    }
}
