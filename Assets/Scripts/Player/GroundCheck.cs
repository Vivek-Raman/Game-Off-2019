using UnityEngine;
 
 public class GroundCheck : MonoBehaviour
 {
     public bool isGrounded = false;
     
     private void OnTriggerEnter2D(Collider2D other)
     {
         isGrounded = other.CompareTag("Ground");
     }
 
     private void OnTriggerExit2D(Collider2D other)
     {
         isGrounded = !other.CompareTag("Ground");
         
     }
 }