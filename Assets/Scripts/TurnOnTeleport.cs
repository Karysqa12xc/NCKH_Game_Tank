using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnOnTeleport : MonoBehaviour
{
    [SerializeField] private Behaviour teleportScript, moveTankScript, fireTankScript, PlantingScript;
    [SerializeField] private GameObject turnOnTeleUI, howToTeleport;
    [SerializeField] private Button turnOffBtn;
    int countTrigger = 0;
    private void Start()
    {
        turnOffBtn.onClick.AddListener(turnOffTeleportTutorial);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && countTrigger == 0)
        {
            Time.timeScale = 0;
            countTrigger++;   
            turnOnTeleUI.SetActive(true);
            howToTeleport.SetActive(true);
            teleportScript.enabled = true;
            moveTankScript.enabled = false;
            fireTankScript.enabled = false;
            PlantingScript.enabled = false;
        }
    }
    public void turnOffTeleportTutorial()
    {
        Time.timeScale = 1;
        howToTeleport.SetActive(false);
        turnOnTeleUI.SetActive(true);
        moveTankScript.enabled = true;
        fireTankScript.enabled = true;
        PlantingScript.enabled = true;
    }
}
