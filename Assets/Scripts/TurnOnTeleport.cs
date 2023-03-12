using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnOnTeleport : MonoBehaviour
{
    [SerializeField] private Behaviour teleportScript;
    [SerializeField] private GameObject turnOnTeleUI, howToTeleport, _Player;
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
            _Player.SetActive(false);
            turnOnTeleUI.SetActive(true);
            howToTeleport.SetActive(true);
            teleportScript.enabled = true;
        }
    }
    public void turnOffTeleportTutorial()
    {
        Time.timeScale = 1;
        _Player.SetActive(true);
        howToTeleport.SetActive(false);
        turnOnTeleUI.SetActive(true);
    }
}
