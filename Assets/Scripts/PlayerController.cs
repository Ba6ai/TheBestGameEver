﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float gravity = 9.8f;
    public float jumpForce;
    public float Speed;

    private float _fallVelocity = 0;

    private Vector3 _moveVector;
    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Movement
        _moveVector = Vector3.zero;
        animator.SetFloat("Speed", 0);
        animator.SetFloat("123", 0);


        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            animator.SetFloat("Speed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            animator.SetFloat("Speed", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            animator.SetFloat("LR", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            animator.SetFloat("LR", -1);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetBool("isGrounded", false);
        } 
        
        

    }

    void FixedUpdate()
    {
        // Movement
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // Stop fall if on the groud
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }
}
