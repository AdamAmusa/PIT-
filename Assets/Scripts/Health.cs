using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [System.Serializable]
    public class GameObjectStringEvent : UnityEvent<GameObject, string> { }
    //event to be called when the object is hit
    public GameObjectStringEvent OnHitWithReference;

    //function to be called when the object is hit
    public void onHit(GameObject sender, string move){
        OnHitWithReference?.Invoke(sender, move); 
    }
}
