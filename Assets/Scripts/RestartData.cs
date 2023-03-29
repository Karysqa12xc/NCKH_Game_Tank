using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartData : MonoBehaviour
{
    public void RestrartData(){
        PlayerPrefs.DeleteAll();
    }
}
