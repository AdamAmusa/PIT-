using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{


    [System.Serializable]
    public class GameObjectStringEvent : UnityEvent<GameObject, string> { }
    //event to be called when the object is hit
    public GameObjectStringEvent OnHitWithReference;
    AudioManager audiomanagerObject;


    public void Start(){
        audiomanagerObject = FindAnyObjectByType<AudioManager>();
    }

    //function to be called when the object is hit
    public void onHit(GameObject sender, string move){
        StartCoroutine(Indicator(Color.black));
        audiomanagerObject.playPunchLand();
        OnHitWithReference?.Invoke(sender, move); 
    }


    private IEnumerator Indicator(Color color){
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
