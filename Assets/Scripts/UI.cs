using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{

    public TextMeshProUGUI scoreText, enemiesLeft, round;
    private EnemySpawner enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindObjectOfType<EnemySpawner>();
        scoreText.text = "Score: 0";
        round.text = "Round: 1";
        
        enemiesLeft.text = "Total Enemies:" + enemies.GetNumberOfEnemies();
        Debug.Log(enemies.GetNumberOfEnemies());
    }

  
}
