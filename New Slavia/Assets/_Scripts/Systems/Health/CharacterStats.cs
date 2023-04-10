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

    protected virtual void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    protected virtual void Die()
    {
    }
}