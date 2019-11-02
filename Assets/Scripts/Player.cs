using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canMove = true;
    public bool canJump = true;
    public float movementSpeed = 5f;
    public float gravity = -1f;

    private float _inH;
    private float _inV;
    private CharacterController _controller = null;

    private void Awake()
    {
        this.TryGetComponent(out _controller);
    }

    private void Update()
    {
        _inH = Input.GetAxis("Horizontal");
        _inV = Input.GetAxis("Vertical");
        
        Move();
        Jump();
    }

    private void Move()
    {
        if (canMove)
        {
            _controller.Move(_inH * 60f * Time.deltaTime * movementSpeed * Vector3.right);
        }
    }

    private void Jump()
    {
        if (_controller.isGrounded && canJump == false)
        {
            canJump = true;
        }
    }
}