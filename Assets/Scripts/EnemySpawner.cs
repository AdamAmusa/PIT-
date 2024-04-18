using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;

    private GameManager gameManager;
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private float spawnInterval = 3.5f;
    private int enemiesSpawned = 0;

    private int spawnQuantity = 5;
    private int currentEnemies;
    private int score = 0;
    private int round = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemies = spawnQuantity;

        StartCoroutine(SpawnEnemy(spawnInterval, swarmerPrefab));

    }


    void Update()
    {
        Debug.Log("Current Enemies " + currentEnemies);
        checkRoundFinished();

    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {


        if (enemiesSpawned < spawnQuantity - 1)
        {

            yield return new WaitForSeconds(interval);

            // Calculate a random angle between 0 and 180 degrees (which is the top half of a circle)
            float angle = Random.Range(0f, 180f) * Mathf.Deg2Rad;

            // Calculate the x and y coordinates using the cosine and sine of the angle
            float x = spawnRange * Mathf.Cos(angle);
            float y = spawnRange * Mathf.Sin(angle) + 0.8f;
            //Debug.Log("Spawning Enemy at " + x + ", " + y);

            GameObject newEnemy = Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
            StartCoroutine(SpawnEnemy(interval, enemy));
            enemiesSpawned++;
           // Debug.Log("Spawning Enemy " + enemiesSpawned);
            
        }
        
    
    }

    void checkRoundFinished(){
        if(currentEnemies == 0)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
            score += 100;
            gameManager.storeScores(score);
            Debug.Log("Round " + round + " Complete");
            round++;
            spawnQuantity += 2;
            currentEnemies = spawnQuantity;
            enemiesSpawned = 0;
            StartCoroutine(SpawnEnemy(spawnInterval, swarmerPrefab));
        }
    }

    public int GetTotalEnemies()
    {
        return spawnQuantity;
    }

    public void reduceEnemies()
    {

        score += 10;
        currentEnemies--;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.storeScores(score);
    }

    public int getScore(){
        return score;
    }

    


    public int getRound()
    {
        return round;
    }

    public int getcurrentEnemies()
    {
        return currentEnemies;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}
