using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject swarmerPrefab;
    
    [SerializeField] private float spawnRange = 5f;
    [SerializeField]private float spawnInterval = 3.5f;
    private int enemiesSpawned = 0;
    
    private int spawnQuantity = 5;
    private int currentEnemies;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemies = spawnQuantity;
        StartCoroutine(SpawnEnemy(spawnInterval, swarmerPrefab));
    }

  private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {

        if (enemiesSpawned < spawnQuantity)
        {
            Debug.Log("Spawning Enemy");
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(0, spawnRange), 0), Quaternion.identity);
            StartCoroutine(SpawnEnemy(interval, enemy));
            enemiesSpawned++;
        }
    }

    public int GetTotalEnemies(){
        return spawnQuantity;
    }

    public void reduceEnemies(){
         currentEnemies--;
    }

    public int getcurrentEnemies(){
        return currentEnemies;
        }

      void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}
