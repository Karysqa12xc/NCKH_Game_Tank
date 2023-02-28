using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]private ParticleSystem Effect;
    private void OnCollisionEnter(Collision other)
    {
        Effect.Play();
        if(other.gameObject.tag != "BulletRed") Destroy(gameObject);
    }
}
