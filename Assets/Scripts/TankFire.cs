using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    public GameObject Shell;
    public float speedBullet = 10f;
    public Transform FireStart;
    private Transform mCannon;
    // Start is called before the first frame update
    void Start()
    {
        mCannon = FireStart.parent;
    }

    public void Shoot()
    {
        GameObject rbShell;
        rbShell = Instantiate(Shell, FireStart.position, mCannon.rotation);
        rbShell.GetComponent<Rigidbody>().velocity = mCannon.forward * speedBullet;
        Destroy(rbShell, 1f);
        
        
    }

    public void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}