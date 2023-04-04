using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private float _experience;
    [SerializeField] private float _gold;

    [SerializeField] private GameObject expOrbPrefab;
    [SerializeField] private GameObject goldOrbPrefab;

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