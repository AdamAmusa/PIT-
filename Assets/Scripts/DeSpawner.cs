using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeSpawner : MonoBehaviour
{
    private EnemySpawner enemyNum;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyNum = GameObject.FindObjectOfType<EnemySpawner>();
            enemyNum.reduceEnemies();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
