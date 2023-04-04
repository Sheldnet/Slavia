using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("¬вод пользовател€")]
    private PlayerInputControlls _playerInputConstrolls;

    private InputAction _playerLook;
    private InputAction _playerMove;

    [HideInInspector]
    public Vector2 MoveDirection;

    [HideInInspector]
    public float LookDirection;

    private void Awake()
    {
        _playerInputConstrolls = new PlayerInputControlls();

        _playerMove = _playerInputConstrolls.PlayerGameProcess.Move;
        _playerLook = _playerInputConstrolls.PlayerGameProcess.Look;
    }

    private void OnDisable()
    {
        _playerInputConstrolls.PlayerGameProcess.Disable();
        _playerMove.Disable();
        _playerLook.Disable();
    }

    private void OnEnable()
    {
        _playerInputConstrolls.PlayerGameProcess.Enable();
        _playerMove.Enable();

        _playerLook.Enable();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        MoveDirection = _playerMove.ReadValue<Vector2>();
        LookDirection = (Mathf.Atan2(_playerLook.ReadValue<Vector2>().y, _playerLook.ReadValue<Vector2>().x) * Mathf.Rad2Deg);
    }
}