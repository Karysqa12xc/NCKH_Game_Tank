using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColiderOfTank : MonoBehaviour
{
    [SerializeField]private GameObject fireNoticeTutorial, checkPoint_2;
    [SerializeField]private Behaviour moveTankBehavior, reloadBullet, fireScript;
    [SerializeField]private Button quitButtonTutorial;
    [SerializeField]private TakeItems pickItems;
    [SerializeField] private HealCharater healOfPlayer;
    private void Start() 
    {
        quitButtonTutorial.onClick.AddListener(turnOffFireTutorial);
        healOfPlayer = GetComponent<HealCharater>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Checkpoint_2")
        {
            Time.timeScale = 0;
            fireNoticeTutorial.SetActive(true);
            moveTankBehavior.enabled = false;
        }
        if(other.gameObject.tag == "Bomb"){
            pickItems.pickItem(other.gameObject);
        }
    }
    public void turnOffFireTutorial()
    {
        Time.timeScale = 1;
        fireNoticeTutorial.SetActive(false);
        fireScript.enabled = true;
        moveTankBehavior.enabled = true;
        reloadBullet.enabled = true;
        Destroy(checkPoint_2);
    }
}
