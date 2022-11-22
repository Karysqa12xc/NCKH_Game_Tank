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
    private Rigidbody rb;
    private Tank_Inputs inputs;
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
}
