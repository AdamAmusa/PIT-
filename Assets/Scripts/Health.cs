using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    public UnityEvent<GameObject> OnHitWithReference;

    public void onHit(GameObject sender){
        OnHitWithReference?.Invoke(sender); 
    }
}
