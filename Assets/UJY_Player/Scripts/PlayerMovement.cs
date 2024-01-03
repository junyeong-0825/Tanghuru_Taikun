using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _controller;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ApplyMovement(_moveDirection);
    }

    private void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= 5;
        _rigidbody2D.velocity = direction;

    }


}
