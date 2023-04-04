using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    public Stat Damage;
    public Stat AttackSpeed;
    public Stat Range;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
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