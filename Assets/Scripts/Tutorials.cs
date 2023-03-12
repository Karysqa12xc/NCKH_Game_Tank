using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    [SerializeField] private GameObject noticeMoveTutorial, _Player, 
    noticePlantingTutorial, fireNoticeTutorial, checkPoint_2, stopTankDes, pauseDes, plantingUI;
    [SerializeField] private Button[] quitButtonTutorial;
    [SerializeField] private Behaviour moveTankBehavior, reloadAmmo, fireScript, plantingBombScript;
    private int countTrigerTutorial = 0;
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
   
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Checkpoint_2")
        {
            Time.timeScale = 0;
            fireNoticeTutorial.SetActive(true);
            fireScript.enabled = true;
            _Player.SetActive(false);
            countTrigerTutorial++;
        }
        if (other.gameObject.tag == "Player" && countTrigerTutorial == 0)
        {
            Time.timeScale = 0;
            noticePlantingTutorial.SetActive(true);
            _Player.SetActive(false);
            plantingUI.SetActive(true);
            plantingBombScript.enabled = true;
            
        }
        
    }
    public void turnOffPlantingTutorial()
    {
        Time.timeScale = 1;
        _Player.SetActive(true);
        noticePlantingTutorial.SetActive(false);
        Destroy(gameObject);
    }
    public void turnOffMoveTutorial()
    {
        Time.timeScale = 1;
        _Player.SetActive(true);
        noticeMoveTutorial.SetActive(false);
        moveTankBehavior.enabled = true;
    }
     public void turnOffFireTutorial()
    {
        Time.timeScale = 1;
        _Player.SetActive(true);
        fireNoticeTutorial.SetActive(false);
        reloadAmmo.enabled = true;
        Destroy(checkPoint_2);
    }
    private void Update()
    {
        quitButtonTutorial[0].onClick.AddListener(turnOffMoveTutorial);
        quitButtonTutorial[1].onClick.AddListener(turnOffFireTutorial);
        quitButtonTutorial[2].onClick.AddListener(turnOffPlantingTutorial);
    }
}
