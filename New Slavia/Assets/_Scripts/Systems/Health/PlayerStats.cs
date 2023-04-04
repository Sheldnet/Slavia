using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Stat BulletSpeed;

    protected override void Die()
    {
        base.Die();
        Debug.Log("γγ σμεπ");
    }
}