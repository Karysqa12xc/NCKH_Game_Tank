using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AklbuAlapba : MonoBehaviour
{
    public int pointsCount;
    public float maxRadius;
    public int speed;
    public float startWidth;
    public float force;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount + 1;
    }
    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Blast());
    }
    private void Update()
    {
        Invoke("DestroyBomb", 0.1f);
    }
    private IEnumerator Blast()
    {
        float currentRadius = 0f;
        while (currentRadius < maxRadius)
        {
            currentRadius += Time.deltaTime * speed;
            Draw(currentRadius);
            DameBomb(currentRadius);
            yield return null;
        }
    }
    private void DameBomb(float currentRadius)
    {
        Collider[] hittingObjects = Physics.OverlapSphere(transform.position, currentRadius);
        for (int i = 0; i < hittingObjects.Length; i++)
        {
            Rigidbody rb = hittingObjects[i].GetComponent<Rigidbody>();
            HealCharater heal = hittingObjects[i].GetComponent<HealCharater>();
            if (hittingObjects[i].gameObject.tag == "CheckPoint")
            {
                Vector3 direction = (hittingObjects[i].transform.position - transform.position).normalized;
                rb.AddForce(direction * force, ForceMode.Impulse);
                heal.TakeDamge(1);
                heal.EnemyDie();
                heal.DropItemWhenEnemiesDie();
            }
        }

    }
    private void Draw(float currentRadius)
    {
        float angleBetweenPoint = 360f / pointsCount;
        for (int i = 0; i <= pointsCount; i++)
        {
            float angle = i * angleBetweenPoint * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }
        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);
    }
}
