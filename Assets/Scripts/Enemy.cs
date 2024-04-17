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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if(hMove < 0){
           gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
         if(hMove > 0){
           gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
    }

   

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
