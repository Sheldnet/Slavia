using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Передвижение")]
    [SerializeField] public Stat MoveSpeed;

    public Stat DashSpeed;

    private Rigidbody2D _playerRb;

    private PlayerInput _playerInput;

    private bool isDashed = false;
    private bool canDash = true;
    private Vector3 _dashDirection;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.OnDashButtonPressed += (float dashDuration, float dashCooldown) =>
        {
            StartCoroutine(Dash(dashDuration, dashCooldown));
        };
    }

    private void FixedUpdate()
    {
        if (isDashed)
        {
            _playerRb.velocity = _dashDirection * DashSpeed.GetValue();
        }
        else
        {
            _playerRb.velocity = _playerInput.MoveDirection.normalized * MoveSpeed.GetValue();
        }
    }

    private IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        if (canDash)
        {
            canDash = false;
            Debug.Log("Начал дэш");
            isDashed = true;
            if (_playerInput.MoveDirection == Vector2.zero)
            {
                _dashDirection = Vector2.right.normalized;
            }
            else
            {
                _dashDirection = _playerInput.MoveDirection.normalized;
            }

            yield return new WaitForSeconds(dashDuration);
            Debug.Log("Закончил дэш");
            isDashed = false;
            yield return new WaitForSeconds(dashCooldown - dashDuration);
            Debug.Log("Кулдаун закончен");
            canDash = true;
        }
    }
}