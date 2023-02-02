using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTutorial : MonoBehaviour
{
    [SerializeField]private Behaviour fireScript;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Checkpoint_2")
        {
            fireScript.enabled = true;
        }
    }
}
