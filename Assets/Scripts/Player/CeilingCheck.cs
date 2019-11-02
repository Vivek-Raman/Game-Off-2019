using UnityEngine;

public class CeilingCheck : MonoBehaviour
{
    public bool isRoofed = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        isRoofed = other.CompareTag("Ground");
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        isRoofed = !other.CompareTag("Ground");
    }
}