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
    public float acceleration = 1000f;
    public float breakingForce = 600f;
    public float maxTurnAngle = 15f;
    [Header("Wheel Controller")]
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider backLeft;
    [Header("Wheel Transfrom")]
    [SerializeField] Transform frontRightTransfrom;
    [SerializeField] Transform frontLeftTransfrom;
    [SerializeField] Transform backRightTransfrom;
    [SerializeField] Transform backLeftTransfrom;

    [Header("Audio")]
    [SerializeField] private AudioSource moveSource;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngel = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // characterController = GetComponent<CharacterController>();
        inputs = GetComponent<Tank_Inputs>();
    }
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
        moveSource.Play();
        if (Input.GetKey(KeyCode.Space)){
            moveSource.Pause();
            currentBreakForce = breakingForce;
        }
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
    void updateWheel(WheelCollider col, Transform trans)
    {
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
