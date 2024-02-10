using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
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
        }
    }
}
