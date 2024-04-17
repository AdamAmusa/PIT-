using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject swarmerPrefab;
    
    [SerializeField] private float spawnRange = 5f;
    [SerializeField]private float spawnInterval = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnInterval, swarmerPrefab));
    }

  private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
            Debug.Log("Spawning Enemy");
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(0, spawnRange), 0), Quaternion.identity);
            StartCoroutine(SpawnEnemy(interval, enemy));

    
    }

    
      void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}
