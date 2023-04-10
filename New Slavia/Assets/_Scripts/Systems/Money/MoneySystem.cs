using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [Header("Gold")]
    [SerializeField] private float _goldFactor;

    [SerializeField] private float _goldScore;
    [SerializeField] private float _goldFromOrb;
    [SerializeField] public float FinalGold;
    [SerializeField] private float _bonusGold;
    public static Action<float> OnExperinceValueChanged;

    // Start is called before the first frame update
    private void Start()
    {
        FinalGold = _goldFromOrb;
        OnExperinceValueChanged.Invoke(_goldScore);
    }

    public void TakeGold()
    {
        _goldScore += FinalGold;
        OnExperinceValueChanged.Invoke(_goldScore);
    }

    public void BuffGold(Item item)
    {
        if (_goldFromOrb * (_goldFactor * item.amount + 1) > _bonusGold)
            _bonusGold = _goldFromOrb * (_goldFactor * item.amount + 1);
        FinalGold = _bonusGold;
    }
}