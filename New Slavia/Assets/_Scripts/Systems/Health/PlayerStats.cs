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

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Die()
    {
        base.Die();
        // Debug.Log("γγ σμεπ");
    }
}