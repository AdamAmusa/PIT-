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
        
        
 
    }

    void Update()
    {
        
        enemiesLeft.text = "Total Enemies: " + enemies.getcurrentEnemies() + "/" + enemies.GetTotalEnemies();
        round.text = "Round: " + enemies.getRound();
        scoreText.text = "Score: " + enemies.getScore();
    }

  
}
