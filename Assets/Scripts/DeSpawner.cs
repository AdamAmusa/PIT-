using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
