using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Передвижение")]
    [SerializeField] public float MoveSpeed;

    private Rigidbody2D _playerRb;

    private PlayerInput _playerInput;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        _playerRb.velocity = _playerInput.MoveDirection.normalized * MoveSpeed;
    }
}