using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float _baseValue;

    [SerializeField] private float _multiplier = 1;
    [SerializeField] private float _bonusValue;

    public float GetValue()
    {
        return _baseValue * _multiplier + _bonusValue;
    }

    public void SetMultiplier(float multiplier)
    {
        _multiplier = multiplier;
    }

    public void SetBonus(float bonus)
    {
        _bonusValue = bonus;
    }
}