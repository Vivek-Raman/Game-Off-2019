using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Properties")]
    public float movementSpeed = 5f;
    public float jumpHeight = 15f;
    public float airTime = 15f;
    
    private float _jumpSpeed = 0f;
    private float _gravity = 0f;

    [SerializeField] private GroundCheck groundCheck = null;
    private Rigidbody2D _rb = null;
    
    private bool _canMove = true;
    private bool _canJump = true;
    private float _inH = 0f;
    private float _inV = 0f;
    private Vector2 _movement = Vector2.zero;
    private Vector2 _downForce = Vector2.zero;
    
    private void Awake()
    {
        this.TryGetComponent(out _rb);
        
        _jumpSpeed = 4 * jumpHeight / airTime;
        _gravity = 2 * _jumpSpeed / airTime;
    }

    private void Update()
    {
        _inH = Input.GetAxis("Horizontal");
        _inV = Input.GetAxis("Vertical");
        
        if (_canMove)
        {
            Move();
        }
        if (groundCheck.isGrounded)
        {
            _canJump = true;
        }
        
        if (Input.GetButtonDown("Jump") && _canJump)
        {
            _canJump = false;
            Jump();
        }
        
        _rb.velocity = _movement + _downForce;
    }

    private void Move()
    {
        _movement = _inH * movementSpeed * Vector2.right;
        _downForce = !groundCheck.isGrounded ? _downForce + _gravity * Vector2.down : Vector2.zero;
    }

    private void Jump()
    {
        _movement += _jumpSpeed * Vector2.up;
    }
}