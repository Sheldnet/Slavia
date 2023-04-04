using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    protected override void Die()
    {
        base.Die();
        Debug.Log(transform.name + " умер");
        Destroy(gameObject);
    }
}