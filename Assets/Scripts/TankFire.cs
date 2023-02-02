using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    public GameObject Shell, rbShell;
    public float speedBullet = 30f;
    public Transform FireStart;
    private Transform mCannon;
    private moveTutorial isClickQuitBtnTutorial;
    // Start is called before the first frame update
    void Start()
    {
        mCannon = FireStart.parent;
    }

    public void Shoot()
    {  
        if(Input.GetMouseButtonDown(0))
        {
            rbShell = Instantiate(Shell, FireStart.position, mCannon.rotation);
            rbShell.GetComponent<Rigidbody>().velocity = mCannon.forward * speedBullet;
        }
        Destroy(rbShell, 1f);
    }

    public void FixedUpdate()
    {
        Shoot();
    }
}