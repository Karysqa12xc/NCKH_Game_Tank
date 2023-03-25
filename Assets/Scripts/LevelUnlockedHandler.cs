using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUnlockedHandler : MonoBehaviour
{
    [SerializeField] Button[] levelBtn;
    int unlokcedLevelNumber;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
        unlokcedLevelNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for(int i = 0; i < levelBtn.Length; i++){
            levelBtn[i].interactable = false;
        }
    }
    private void Update()
    {
        unlokcedLevelNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for(int i = 0; i < unlokcedLevelNumber; i++){
            levelBtn[i].interactable = true;
        }
    }
}
