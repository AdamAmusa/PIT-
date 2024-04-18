using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Serializers;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public Animator animator;
    private Rigidbody2D rb;
    private float distance;
    public float speed;

    public EnemyData enemyData;

    private float hMove;
    private Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            GetTarget();
        }
        else
        { // Move the enemy towards the player
            Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.position = newPosition;

            // Calculate the actual speed of the enemy
            float actualSpeed = (newPosition - lastPosition).magnitude / Time.deltaTime;
            if (newPosition.x > lastPosition.x)
            {
                // Moving right
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (newPosition.x < lastPosition.x)
            {
                // Moving left
                transform.localScale = new Vector3(-1, 1, 1);
            }
            lastPosition = newPosition;

            animator.SetFloat("Speed", Mathf.Abs(actualSpeed));
            // Debug.Log(player.transform.position);}

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());

            // Get the player's Rigidbody2D
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();

            // Calculate the knockback direction
           Vector2 knockbackDirection = new Vector2(Mathf.Sign(playerRb.transform.position.x - transform.position.x), 0);
            //knockbackDirection.Normalize();
            

            // Apply the knockback force
            float knockbackForce = 50f;
            other.rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            Debug.Log("Player collided with enemy!");
        }
    }

    void GetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}