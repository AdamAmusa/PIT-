using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator animator;


    [SerializeField] private float jumpForce;
    
    
    bool grounded;
   

    
    private Rigidbody2D rb;
    private float hMove;



    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetKey("space") && grounded)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }


    }

    void FixedUpdate(){
        rb.velocity = new Vector2(hMove * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            grounded = true;
        }
    }

     private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }


    //When two colliders come into contact

}
