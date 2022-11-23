using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Tank_Inputs))]
public class Tank_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement Properties")]
    public float tankSpeed = 15f;
    public float tankRotationSpeed = 100f;
    [Header("Turret Properties")]
    public Transform turretTransfron;
    public float turretLagSpeed = 1.0f;
    [Header("CrossHair Properties")]
    public Transform crossHairTranfrom;
    private Rigidbody rb;
    private Tank_Inputs inputs;
    private Vector3 finalTurretLookDir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputs = GetComponent<Tank_Inputs>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb && inputs)
        {
            HandleMovement();
            HandleTurret();
            HandleCrossHair();
        }
    }
    protected virtual void HandleMovement()
    {
        //Move tank forward
        Vector3 wantedPosition = transform.position + (transform.forward * inputs.ForwardInput * tankSpeed * Time.deltaTime);
        rb.MovePosition(wantedPosition);

        //Move tank rotation
        Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * inputs.RotationInput * tankRotationSpeed * Time.deltaTime);
        rb.MoveRotation(wantedRotation);
    }
    protected virtual void HandleTurret()
    {
        if (turretTransfron)
        {
            Vector3 turretLookDir = inputs.CrosshairPosition - turretTransfron.position;
            turretLookDir.y = 0f;
            finalTurretLookDir = Vector3.Lerp(finalTurretLookDir, turretLookDir, turretLagSpeed * Time.deltaTime);
            turretTransfron.rotation = Quaternion.LookRotation(turretLookDir);
        }
    }
    protected virtual void HandleCrossHair()
    {
        if (crossHairTranfrom)
        {
            crossHairTranfrom.position = new Vector3(1,1,1);
            crossHairTranfrom.position = inputs.CrosshairPosition;
        }
    }


}
