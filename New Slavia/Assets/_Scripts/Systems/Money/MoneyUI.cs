using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private float velocityGold;

    private void Awake()
    {
        MoneySystem.OnExperinceValueChanged += SetGoldText;
    }

    public void SetGoldText(float currentGold)
    {
        goldText.text = currentGold.ToString();
    }
}