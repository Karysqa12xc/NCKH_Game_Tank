using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    public GameObject Shell;
    private GameObject rbShell;
    public float speedBullet = 10;
    public Transform FireStart;
    private Transform mCannon;
    public void Update()
    {  
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rbShell = Instantiate(Shell, FireStart.position, FireStart.rotation);
            rbShell.GetComponent<Rigidbody>().velocity = FireStart.forward * speedBullet;
        }
        Destroy(rbShell, 1f);
    }
}