using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    [SerializeField] private GameObject noticeMoveTutorial, noticePlantingTutorial, stopTankDes, pauseDes, plantingUI;
    [SerializeField] private Button[] quitButtonTutorial;
    [SerializeField] private Behaviour moveTankBehavior, reloadAmmo, plantingBombScript;
    void Start()
    {
        Invoke("turnOnMoveTutorial", 1.5f);  
    }
    public void turnOnMoveTutorial()
    {
        Time.timeScale = 0;
        noticeMoveTutorial.SetActive(true);
        moveTankBehavior.enabled = false;
        reloadAmmo.enabled = false;
        stopTankDes.SetActive(true);
        pauseDes.SetActive(true);
    }    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            Time.timeScale = 0; 
            noticePlantingTutorial.SetActive(true);
            moveTankBehavior.enabled = false;
            plantingUI.SetActive(true);
            plantingBombScript.enabled = true;
            reloadAmmo.enabled = false;    
        }
    }
    public void turnOffPlantingTutorial(){
        Time.timeScale = 1;
        noticePlantingTutorial.SetActive(false);
        moveTankBehavior.enabled = true;
        reloadAmmo.enabled = true;
        Destroy(gameObject);
    }
    public void turnOffMoveTutorial()
    {
        Time.timeScale = 1;
        noticeMoveTutorial.SetActive(false);
        moveTankBehavior.enabled = true;
    }
    private void Update() {
        quitButtonTutorial[0].onClick.AddListener(turnOffMoveTutorial);
        quitButtonTutorial[1].onClick.AddListener(turnOffPlantingTutorial);
    }
}
