using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTurretEnemy : MonoBehaviour
{
    
    [SerializeField]Transform _Player;
    float dist;
    [SerializeField]private float speedBullet;
    [SerializeField]private float howClose;
    public Transform tower, bulletPreabs;
    public GameObject _projectile;
    public float fireRate, nextFire;
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    private void Update() {
        TurrertCtrl();
    }
    public void TurrertCtrl()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if (dist <= howClose)
        {
            tower.LookAt(_Player);
            if(Time.time > nextFire){
                nextFire = Time.time + 1f / fireRate;
                ShootOfEnemy();
            }
            
        }
    }

    public void ShootOfEnemy()
    {
        GameObject cloneBulletOfEnemy =  Instantiate(_projectile, bulletPreabs.position, bulletPreabs.rotation);
        cloneBulletOfEnemy.GetComponent<Rigidbody>().velocity = bulletPreabs.forward * speedBullet;
        Destroy(cloneBulletOfEnemy, 1f);
    }
}
