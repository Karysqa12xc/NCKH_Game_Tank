using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    Vector3 posittionOfMouse;
    [SerializeField] Tank_Inputs getPositionTeleport;
    private void Start()
    {
        getPositionTeleport = GetComponent<Tank_Inputs>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PlayerTeleport();
        }
    }

    private void PlayerTeleport()
    {
        posittionOfMouse = getPositionTeleport.CrosshairPosition;
        gameObject.transform.position = posittionOfMouse;
    }
}
