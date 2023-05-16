using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public float MaxHealth;
    private float _currentHealth;
    public float healthFactor;
    public Stat Damage;
    public Stat AttackSpeed;
    public Stat AttackRange;

    protected bool _isInvincibility = false;

    protected virtual void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (!_isInvincibility)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    protected virtual IEnumerator BecomeVulnerable(float InvincibilityDuration)
    {
        yield return new WaitForSeconds(InvincibilityDuration);
        _isInvincibility = false;
    }

    protected virtual void Die()
    {
    }
}