using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator animator;

    [SerializeField] private float jumpForce;
    
    bool grounded;
   
    private Rigidbody2D rb;
    private float hMove;
    private Vector2 lastPosition;



    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetKey("space") && grounded)
        {
           // animator.SetTrigger("Jump");
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }


    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate(){
        rb.velocity = new Vector2(hMove * speed, rb.velocity.y);

        //Flip the character
        if(hMove < 0){
           gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
         if(hMove > 0){
           gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //When two colliders come into contact
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { 
            grounded = true;
            animator.SetBool("isJumping", false);
            Debug.Log("Grounded");
            
        }
    }

    void onLand(GameObject sender){
        animator.ResetTrigger("Jump");
    }

    //When two colliders come into contact
     private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", true);
            grounded = false;
        }
    }


    //When two colliders come into contact

}
