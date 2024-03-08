using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //event to be called when the object is hit
    public UnityEvent<GameObject> OnHitWithReference;

    //function to be called when the object is hit
    public void onHit(GameObject sender){
        OnHitWithReference?.Invoke(sender); 
    }
}
