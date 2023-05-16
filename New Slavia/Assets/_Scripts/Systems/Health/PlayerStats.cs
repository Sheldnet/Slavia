using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Stat BulletSpeed;
    public Stat PickUpRange;
    public float DamageReduction;
    public Stat BulletSize;
    public Stat CritChance;

    private PlayerInput _playerInput;
    private bool canDash = true;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnDashButtonPressed += (float dashDuration, float dashCooldown) =>
        {
            StartCoroutine(Dash(dashDuration, dashCooldown));
        };
    }

    protected override void Die()
    {
        base.Die();
        // Debug.Log("γγ σμεπ");
    }

    private IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        if (canDash)
        {
            canDash = false;
            _isInvincibility = true;
            yield return new WaitForSeconds(dashDuration);
            _isInvincibility = false;
            yield return new WaitForSeconds(dashCooldown - dashDuration);
        }
    }
}