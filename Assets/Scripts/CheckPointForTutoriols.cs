using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointForTutoriols : MonoBehaviour
{
    [SerializeField] private GameObject moveTutorial;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("turnOnMoveTutorial", 1.5f);
    }
    public void turnOnMoveTutorial(){
        moveTutorial.SetActive(true);
    }
    public void  turnOffMoveTutorial(){
        if(Input.GetMouseButtonDown(1)){
            moveTutorial.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        turnOffMoveTutorial();
    }
}
