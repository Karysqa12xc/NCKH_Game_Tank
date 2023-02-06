using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireTutorial : MonoBehaviour
{
    [SerializeField]private GameObject fireNoticeTutorial, checkPoint_2;
    [SerializeField]private Behaviour moveTankBehavior, reloadBullet, fireScript;
    [SerializeField]private Button quitButtonTutorial;
    
    private void Start() 
    {
        quitButtonTutorial.onClick.AddListener(turnOffFireTutorial);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Checkpoint_2")
        {
            fireNoticeTutorial.SetActive(true);
            moveTankBehavior.enabled = false;
        }
    }
    public void turnOffFireTutorial()
    {
        fireNoticeTutorial.SetActive(false);
        fireScript.enabled = true;
        moveTankBehavior.enabled = true;
        reloadBullet.enabled = true;
        Destroy(checkPoint_2);
    }
}
