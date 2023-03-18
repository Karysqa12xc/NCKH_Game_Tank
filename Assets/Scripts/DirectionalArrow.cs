using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private GameObject targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = GameObject.FindGameObjectWithTag("NextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPointPosition = targetPoint.transform.position;
        targetPointPosition.y = transform.position.y;
        transform.LookAt(targetPointPosition);
        
    }
}
