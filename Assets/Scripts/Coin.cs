using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject _render = null;
    private GameObject _fx = null;

    private void Awake()
    {
        _render = transform.GetChild(0).gameObject;
        _fx = transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        // add to collection
        Debug.Log("Coin picked up");
        this.GetComponent<BoxCollider2D>().enabled = false;
        
        // spawn animation / particles
        _render.SetActive(false);
        _fx.SetActive(true);
        
        Destroy(this.gameObject, 1f);
    }
}
