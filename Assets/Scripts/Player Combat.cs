using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{

    public Transform jabPoint;
    public float attackRange = 0.5f;    
    public LayerMask enemyLayers;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey("f"))
        {
            
            Attack();
            
        }

    }

    void Attack(){
        animator.SetTrigger("Attack"); 

    }


    void animationFinished(GameObject sender){
        Debug.Log("Animation Finished");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(jabPoint.position, attackRange, enemyLayers);

        //loops through all the enemies that were hit
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
            Health health = enemy.GetComponent<Health>();   
            health.onHit(this.gameObject);
        }

        animator.ResetTrigger("Attack");
    }

    void OnDrawGizmosSelected(){
        //if the jabPoint is not set, return
        if(jabPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(jabPoint.position, attackRange);
    }



}
