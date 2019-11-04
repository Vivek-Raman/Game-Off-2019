using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Properties")]
    public float movementSpeed = 5f;
    [Range(0f, 1f)] public float airControlModifier = 0.75f;

    private CharacterController2D _controller = null;
    private float _inH = 0f;
    private float _inV = 0f;

    private float speed = 0f;
    private bool _jump = false;

    private void Awake()
    {
        this.TryGetComponent(out _controller);
        speed = movementSpeed;
    }

    private void Update()
    {
        _inH = Input.GetAxis("Horizontal");
        _inV = Input.GetAxis("Vertical");
        _jump = Input.GetButtonDown("Jump");
        
        
        _controller.Move(_inH * speed, false, _jump);
    }

    public void CallOnJump()
    {
        speed = movementSpeed * airControlModifier;
    }

    public void CallOnLand()
    {
        speed = movementSpeed;
    }
}
