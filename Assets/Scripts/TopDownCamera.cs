using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TopDownCamera : MonoBehaviour
{
    public Transform m_Target;
    [SerializeField] private float m_Height = 16f;
    [SerializeField] private float m_Distance = 20f;
    [SerializeField] private float m_Angle = 45f;
    [SerializeField] private float m_SmoothSpeed = 0.5f;
    private Vector3 refVelocity;
    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if (!m_Target)
        {
            return;
        }
        //Tạo vị trí theo trục z của vật thể mà camera quay đến
        Vector3 worldPostion = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
        // Debug.DrawLine(m_Target.position, worldPostion, Color.red);
        //Tạo vị trí theo trục x, y của vật thể mà camera quay đến
        Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPostion;
        // Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

        //Di chuyển camara theo vật thể
        Vector3 flatTargetPosition = m_Target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
        transform.LookAt(flatTargetPosition);
    }
}
