using System;
using TreeEditor;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        // add to collection
        Debug.Log("Coin picked up");
        
        // spawn animation / particles
        
        Destroy(this.gameObject, 1f);
    }
}
