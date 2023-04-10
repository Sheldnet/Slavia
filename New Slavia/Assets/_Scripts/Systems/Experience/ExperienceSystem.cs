using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ExperienceSystem : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] private int level = 1;

    [SerializeField] private float experience;
    [SerializeField] private float _experienceFactor;
    [SerializeField] private float maxExp;
    [SerializeField] private float _experienceFromOrb;
    [SerializeField] private float _bonusExperince;
    public float FinalExp;
    public float Level => level;

    public static Action<float, float, float> OnExperinceValueChanged;

    // Start is called before the first frame update
    private void Start()
    {
        FinalExp = _experienceFromOrb;
        OnExperinceValueChanged.Invoke(Level, experience, maxExp);
    }

    public void TakeExperience()
    {
        experience += FinalExp;
        LevelUp();
        OnExperinceValueChanged.Invoke(Level, experience, maxExp);
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

    public void BuffExperience(Item item)
    {
        if (_experienceFromOrb * (_experienceFactor * item.amount + 1) != _bonusExperince)
            _bonusExperince = _experienceFromOrb * (_experienceFactor * item.amount + 1);
        FinalExp = _bonusExperince;
    }
}