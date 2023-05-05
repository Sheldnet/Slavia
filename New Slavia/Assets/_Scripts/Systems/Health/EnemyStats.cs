using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private float _experience;
    [SerializeField] private float _gold;

    [SerializeField] private float _InvincibilityDuration;
    private bool _isInvincibility = false;

    [SerializeField] private GameObject expOrbPrefab;
    [SerializeField] private GameObject goldOrbPrefab;

    private void Update()
    {
    }

    public override void TakeDamage(float damage)
    {
        if (!_isInvincibility)
        {
            base.TakeDamage(damage);
            _isInvincibility = true;
            StartCoroutine(BecomeVulnerable());
        }
    }

    private IEnumerator BecomeVulnerable()
    {
        yield return new WaitForSeconds(_InvincibilityDuration);
        _isInvincibility = false;
    }

    protected override void Die()
    {
        base.Die();
        Debug.Log(transform.name + " умер");
        for (int i = 0; i < _experience; i += 5)
        {
            Instantiate(expOrbPrefab, transform.position, Quaternion.identity);
            Instantiate(goldOrbPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}