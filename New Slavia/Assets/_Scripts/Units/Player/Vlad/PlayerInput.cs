using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    [SerializeField] private float _DashReloadTime = 12f;
    [SerializeField] private float _DashDutation;
    [SerializeField] private Button _dashButton;
    public Action<float, float> OnDashButtonPressed;

    private void Awake()
    {
        _playerInputConstrolls = new PlayerInputControlls();

        _playerMove = _playerInputConstrolls.PlayerGameProcess.Move;
        _playerLook = _playerInputConstrolls.PlayerGameProcess.Look;
        _dashButton.onClick.AddListener(SendDashButtonPressed);
    }

    private void OnDisable()
    {
        _playerInputConstrolls.PlayerGameProcess.Disable();

        _dashButton.onClick.RemoveListener(SendDashButtonPressed);
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

    private void SendDashButtonPressed()
    {
        OnDashButtonPressed?.Invoke(_DashDutation, _DashReloadTime);
    }
}