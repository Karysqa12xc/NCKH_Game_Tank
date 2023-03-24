using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyBase;

    [Header("Parameter rand xPos and zPos")]
    [SerializeField] private int xPosRand1, xPosRand2, zPosRand1, zPosRand2;
    [Header("Position spawn random enemy")]
    public int xPos, zPos;
    private Quest countEnemyWhenSpawn;

    [Header("Quantity enemy spawn")]
    [SerializeField] private int QuantityEnemySpawn;

    void Start()
    {
        countEnemyWhenSpawn = GameObject.Find("QuestUI").GetComponent<Quest>();
        StartCoroutine(EnemySpawnRandom(enemyBase[0]));
        StartCoroutine(EnemySpawnRandom(enemyBase[1]));
        StartCoroutine(EnemySpawnRandom(enemyBase[2]));
    }
    IEnumerator EnemySpawnRandom(GameObject enemy)
    {
        while (countEnemyWhenSpawn.countEnemy < QuantityEnemySpawn)
        {
            xPos = Random.Range(xPosRand1, xPosRand2);
            zPos = Random.Range(zPosRand1, zPosRand2);
            Instantiate(enemy ,new Vector3(xPos, transform.position.y, zPos), Quaternion.identity);
            countEnemyWhenSpawn.countEnemy++;
            yield return new WaitForSeconds(0.1f);

        }
    }
}
