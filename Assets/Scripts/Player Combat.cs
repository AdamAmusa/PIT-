using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    
    public Transform jabPoint;
    public Transform heavyPoint;

    
    public float attackRange = 0.5f;    
    public LayerMask enemyLayers;

    public InputActionAsset playerControls;
    private CombatControls combatControls;


    public Animator animator;
    
    void Awake(){
        combatControls = GetComponent<CombatControls>();
        combatControls.awakeControls();
    }

     void OnEnable()
    {
        combatControls.enableControls();
    }

    void OnDisable()
    {
        combatControls.disableControls();
    }   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        if(Input.GetKey("f"))
        {
            animator.SetTrigger("LightAttack");    
        }

        if(combatControls.upLight.triggered)
        {
            animator.SetTrigger("Light-Up");
            Debug.Log("Light-Up");
        }

        if(Input.GetKey("n"))
        {
            animator.SetTrigger("HeavyAttack");
            Debug.Log("Heavy");
        }   
        
        if(Input.GetKey("n") && Input.GetKey("w"))
        {
            animator.SetTrigger("Heavy-Up");
            Debug.Log("Up Heavy");
        }

        if(Input.GetKey("n") && Input.GetKey("s"))
        {
            animator.SetTrigger("Heavy-Down");
            Debug.Log("Down Heavy");
        }

        if(combatControls.DownLight.triggered)
        {
            animator.SetTrigger("Light-Down");
            Debug.Log("Down Light");
        }


    }
    //function to be called when the animation is finished
    void animationFinished(GameObject sender){
        Debug.Log("Animation Finished");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(jabPoint.position, attackRange, enemyLayers);

        //loops through all the enemies that were hit
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
            Health health = enemy.GetComponent<Health>();   
            health.onHit(this.gameObject);
        }

        animator.ResetTrigger("LightAttack");
    }


    void HeavyFinish(GameObject sender){

        animator.ResetTrigger("HeavyAttack");
    }

    void HeavyUpFinish(GameObject sender){}

    void HeavyDownFinish(GameObject sender){}

    void LightUpFinish(GameObject sender){}

    void LightDownFinish(GameObject sender){}
     


    //draws a wire sphere around the jabPoint
    void OnDrawGizmosSelected(){
        //if the jabPoint is not set, return
        if(jabPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(jabPoint.position, attackRange);
    }



}
