using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Backup
// [RequireComponent(typeof(Rigidbody))]
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
    // private CharacterController characterController;
    private Tank_Inputs inputs;
    private Vector3 finalTurretLookDir;
    [Header("Wheel Controller")]
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider backLeft;

    [SerializeField] Transform frontRightTransfrom;
    [SerializeField] Transform frontLeftTransfrom;
    [SerializeField] Transform backRightTransfrom;
    [SerializeField] Transform backLeftTransfrom;
    public float acceleration = 1500f;
    public float breakingForce = 800f;
    public float maxTurnAngle = 15f;
    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngel = 0f;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // characterController = GetComponent<CharacterController>();
        inputs = GetComponent<Tank_Inputs>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 
        if (rb && inputs)
        {
            HandleMovement();
            HandleTurret();
            HandleCrossHair();
        }
    }
    protected virtual void HandleMovement()
    {
        // //Move tank forward
        // Vector3 wantedPosition = (transform.forward * inputs.ForwardInput * tankSpeed);
        // // rb.MovePosition(wantedPosition);
        // rb.AddForce(wantedPosition);
        // //Move tank rotation
        // Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * inputs.RotationInput * tankRotationSpeed * Time.deltaTime);
        // rb.MoveRotation(wantedRotation);
        currentAcceleration = acceleration * inputs.ForwardInput;
        if(Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currentTurnAngel = maxTurnAngle * inputs.RotationInput;
        frontLeft.steerAngle = currentTurnAngel;
        frontRight.steerAngle = currentTurnAngel;

        updateWheel(frontLeft, frontLeftTransfrom);
        updateWheel(frontRight, frontRightTransfrom);
        updateWheel(backLeft, backLeftTransfrom);
        updateWheel(backRight, backRightTransfrom);
    }
    void updateWheel(WheelCollider col, Transform trans){
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);
        trans.position = position;
        trans.rotation = rotation;
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
            crossHairTranfrom.position = inputs.CrosshairPosition;
        }
    }
}
