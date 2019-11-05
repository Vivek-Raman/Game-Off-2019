using System;
using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    
    [Header("Blink Properties")]
    [SerializeField] private float blinkRadius = 4f;
    [SerializeField] private float blinkSpeed = 1000f;
    [SerializeField] private float dilationDuration = 1f;

    private Rigidbody2D _rb = null;
    private Vector2 _directionToBlink = Vector2.zero;
    private Transform _blinkRingSprite = null;
    private Animator _spriteAnimator = null;
    private bool _timedOut = false;
    private float _dampVelocity = 1f;
    
    private readonly int _animatorPropertyID = Animator.StringToHash("isBlinkKeyPressed");
    private const KeyCode BlinkKey = KeyCode.Joystick1Button0;

    private void Awake()
    {
        _blinkRingSprite = this.transform.GetChild(3);
        _blinkRingSprite.TryGetComponent(out _spriteAnimator);
        this.TryGetComponent(out _rb);
    }

    // TODO: Fix dropped inputs
    
    private void Update()
    {
        if (Input.GetKey(BlinkKey))
        {
            if (Input.GetKeyDown(BlinkKey))
            {
                OnBlinkKeyPressed();
            }

            else
            {
                OnBlinkKeyHeld();
            }
        }
        else
        {
            if (Input.GetKeyUp(BlinkKey))
            {
                StartCoroutine(OnBlinkKeyReleased());
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnBlinkKeyPressed()
    {
        GrowCircle();
        StartCoroutine(Timeout());
    }

    private void OnBlinkKeyHeld()
    {
        // slow down time
        Time.timeScale = Mathf.SmoothDamp(Time.timeScale, 0f, ref _dampVelocity, dilationDuration * 0.3f);

        // set direction
        float inX = Input.GetAxis("Horizontal");
        float inY = Input.GetAxis("Vertical");
        _directionToBlink = new Vector2(inX, inY);
    }

    private IEnumerator OnBlinkKeyReleased()
    {
        yield return new WaitForFixedUpdate();
        if (!_timedOut)
        {
            BlinkToDirection();
        }
        Time.timeScale = 1f;
        _timedOut = false;
        ShrinkCircle();
        StopCoroutine(Timeout());
        yield return null;
    }

    #region Animator Functions

    private void GrowCircle()
    {
        _spriteAnimator.SetBool(_animatorPropertyID, true);
    }

    private void ShrinkCircle()
    {
        _spriteAnimator.SetBool(_animatorPropertyID, false);
    }

    #endregion

    private void BlinkToDirection()
    {
        _directionToBlink.Normalize();
        _rb.MovePosition(this.transform.position + blinkRadius * _directionToBlink.ToVector3());
    }

    private IEnumerator Timeout()
    {
        if (!_timedOut)
        {
            yield return new WaitForSeconds(dilationDuration);
            _timedOut = true;
        }
        
        yield return null;
    }
}