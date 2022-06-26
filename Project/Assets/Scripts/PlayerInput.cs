using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> OnMove;
    private float _direction = 0f;
    private Vector3 _startPosition = Vector3.zero;

    private void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxis("Horizontal"));
#endif
#if UNITY_EDITOR
        GetInputTouch();
#endif
    }

    private void GetInputTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    _direction = touch.position.x > _startPosition.x ? 1f : -1f;
                    _direction *= Time.deltaTime;
                    break;
                default:
                    _startPosition = touch.position;
                    _direction = 0f;
                    break;
            }
            OnMove?.Invoke(_direction);
        }
    }
}
