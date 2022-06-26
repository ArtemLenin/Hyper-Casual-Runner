using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _forwardSpeed = 5;
    [SerializeField] private float _horizontalSpeed = 10;
    private CharacterController _controller;
    private float _moveX = 0f;
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void StartMovement()
    {
        _animator.SetTrigger("StartMovement");
    }

    private void OnEnable()
    {
        PlayerInput.OnMove += MoveHorizontal;
    }

    private void FixedUpdate()
    {
        if (GameController.Instanse.GameStarted)
        {
            Vector3 direction = Vector3.forward * _forwardSpeed * Time.fixedDeltaTime;
            direction.x += _moveX;
            _controller.Move(direction);
        }
    }

    private void MoveHorizontal(float moveX)
    {
        _moveX = moveX * _horizontalSpeed;
    }
}