using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CameraController cam = null;

    [Header("Movement Properties")]
    public float movementSpeed = 1f;
    [Range(0f, 1f)] public float airControlModifier = 0.7f;
    
    private CharacterController2D _controller = null;
    private float _inH = 0f;
    private float _inV = 0f;
    private CamState _camState = CamState.WalkRight;
    private float _speed = 0f;
    private bool _jump = false;

    private void Awake()
    {
        this.TryGetComponent(out _controller);
        _speed = movementSpeed;
    }

    private void Update()
    {
        _inH = Input.GetAxis("Horizontal");
        _inV = Input.GetAxis("Vertical");
        _jump = Input.GetButtonDown("Jump");

        if (_controller.facingRight)
        {
            _camState = _inV > 0.7f ? CamState.LookUpRight : _inV < -0.7f ? CamState.LookDownRight : CamState.WalkRight;
        }
        else
        {
            _camState = _inV > 0.7f ? CamState.LookUpLeft : _inV < -0.7f ? CamState.LookDownLeft : CamState.WalkLeft;
        }
        
        cam.SetActiveCamera(_camState);
        _controller.Move(_inH * _speed, false, _jump);
    }

    public void CallOnJump()
    {
        _speed = movementSpeed * airControlModifier;
    }

    public void CallOnLand()
    {
        _speed = movementSpeed;
    }
}
