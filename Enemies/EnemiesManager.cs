using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] Vector2 spawnArea;
    [SerializeField] Transform player;
    [SerializeField] float spawnTime;
    [SerializeField] float spawnTime2;
    [SerializeField] float spawnTime3;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    float spawnTimer;
    float spawnTimer2;
    float spawnTimer3;
    float buffTimer = 0;

    private void Update()
    {
        buffTimer += Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        spawnTimer2 -= Time.deltaTime;
        spawnTimer3 -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnEnemy(enemy);
            spawnTime = (float)(spawnTime - 0.01);
            spawnTimer = spawnTime;
        }

        if (spawnTimer2 <= 0)
        {
            SpawnEnemy(enemy2);
            spawnTime2 = (float)(spawnTime2 - 0.01);
            spawnTimer2 = spawnTime2;
        }
        if (spawnTimer3 <= 0)
        {
            SpawnEnemy(enemy3);
            spawnTime3 = (float)(spawnTime3 - 0.01);
            spawnTimer3 = spawnTime3;
        }
    }

    public void SpawnEnemy(GameObject enemy)
    {
        Vector3 spawnPosition = GenerateRandomPosition();
            
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = spawnPosition;
        float plusDamage = buffTimer / 100;
        float plusHp = buffTimer / 30;
        newEnemy.GetComponent<Enemy>().IncreaseStats(plusDamage, plusHp);
    }
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        position.z = 0;
        position += player.position;
        return position;
    }
}
