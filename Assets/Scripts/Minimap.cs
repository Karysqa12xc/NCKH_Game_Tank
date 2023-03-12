using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform _Player;
    private void LateUpdate() 
    {
        Vector3 newPosittion = _Player.position;
        newPosittion.y = transform.position.y;
        transform.position = newPosittion;
    }
}
