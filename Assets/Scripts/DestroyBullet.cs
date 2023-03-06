using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]private ParticleSystem Effect;
    [SerializeField]private Transform _Player;
    float dist;
    private void Start() {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() {
        takeCareDistance();
    }
    private void takeCareDistance(){
        dist = Vector3.Distance(_Player.position, transform.position);
        if(dist >= 15){
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Effect.Play();
        
        if(other.gameObject.tag != "BulletRed") Destroy(gameObject);
    }
}
