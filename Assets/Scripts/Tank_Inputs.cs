using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Inputs : MonoBehaviour
{
    [Header("Input Properties")]
    [SerializeField]private Camera Cam;
    [SerializeField]private Vector3 crosshairPosition;
    public Vector3 CrosshairPosition
    {
        get { return crosshairPosition;}
    }

    private Vector3 crosshairNormal;
    public Vector3 CrosshairNormal
    {
        get { return crosshairNormal; }
    }

    private float forwardInput;
    public float ForwardInput
    {
        get { return forwardInput; }
    }
    private float rotationInput;
    public float RotationInput
    {
        get { return rotationInput; }
    }
    void Update()
    {
        if (Cam)
        {
            HandleInputs();
        }
    }
    protected virtual void HandleInputs()
    {
        Ray screenRay = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(screenRay, out hit))
        {
            crosshairPosition = hit.point;
            crosshairNormal = hit.normal;
        }

        forwardInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }
}
