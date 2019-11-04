using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator _animator = null;
    private int _property = 0;
    private int _currentState = 0;
    private void Awake()
    {
        this.TryGetComponent(out _animator);
        _property = Animator.StringToHash("ActiveCamera");
    }

    public void SetActiveCamera(CamState state)
    {
        int s = (int) state;
        if (_currentState == s) return;
        _currentState = s;
        _animator.SetInteger(_property, s);
    }
}
