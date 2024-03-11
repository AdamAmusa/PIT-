using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float strength = 5, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    // Start is called before the first frame update
    public void PlayFeedback(GameObject sender){
        //stop all coroutines
        StopAllCoroutines();
        //invoke the onBegin event
        OnBegin?.Invoke();
        //get the direction from the sender to this object
        Vector2 direction = (transform.position - sender.transform.position).normalized;  
        //add force to the rigidbody
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());  
    }

    private IEnumerator Reset(){
        //wait for the delay
        yield return new WaitForSeconds(delay);
        //reset the velocity of the rigidbody
        rb.velocity = Vector3.zero;
        //invoke the onDone event
        OnDone?.Invoke();
    }
}
