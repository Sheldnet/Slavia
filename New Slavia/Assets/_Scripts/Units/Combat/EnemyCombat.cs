using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private EnemyStats _enemyStats;

    // Start is called before the first frame update
    private void Start()
    {
        _enemyStats = GetComponent<EnemyStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(_enemyStats.Damage.GetValue() / playerStats.DamageReduction);
        }
    }
}