using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Stat BulletSpeed;

    [Header("Gold")]
    [SerializeField] private float goldFactor;

    [SerializeField] private float goldScore;
    [SerializeField] private float goldFromOrb;
    [SerializeField] public float FinalGold;
    [SerializeField] public float FinalExp;

    [Header("Experience")]
    [SerializeField] private int level = 1;

    [SerializeField] private float experience;
    [SerializeField] private float expFactor;
    [SerializeField] private float maxExp;
    [SerializeField] private float expFromOrb;

    public float Level => level;
    public float ExperienceFactor => expFactor;
    public float ExperienceFromOrb => expFromOrb;
    public float MaxExperience => maxExp;
    public float GoldFactor => goldFactor;
    public float GoldFromOrb => goldFromOrb;
    public float CurrentGold
    { get { return goldScore; } private set { } }
    public float CurrentExperience
    { get { return experience; } private set { } }

    protected override void Awake()
    {
        base.Awake();
        FinalExp = expFromOrb;
        FinalGold = goldFromOrb;
    }

    protected override void Die()
    {
        base.Die();
        Debug.Log("γγ σμεπ");
    }

    public void TakeExperience(float addedExperience)
    {
        experience += addedExperience;
        LevelUp();
    }

    public void TakeGold(float addedGold)
    {
        goldScore += addedGold;
        LevelUp();
    }

    private void LevelUp()
    {
        if (experience > maxExp)
        {
            experience -= maxExp;
            level++;
            maxExp *= level;
            //maxHealth*=level;
        }
    }
}