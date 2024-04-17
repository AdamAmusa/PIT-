using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public Animator animator;
    private Rigidbody2D rb;
    private float distance;
    public float speed;

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

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (hMove < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (hMove > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = newPosition;

        // Calculate the actual speed of the enemy
        float actualSpeed = (newPosition - lastPosition).magnitude / Time.deltaTime;
        lastPosition = newPosition;

        // Set the "Speed" parameter based on the enemy's actual speed
        animator.SetFloat("Speed", actualSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
