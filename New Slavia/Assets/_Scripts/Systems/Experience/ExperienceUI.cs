using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceUI : MonoBehaviour
{
    [SerializeField] private Image _expBar;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private float _fillExp;
    [SerializeField] private float _velocityExp;

    private void Awake()
    {
        ExperienceSystem.OnExperinceValueChanged += ExpMan;
    }

    public void ExpMan(float currentLvl, float currentExperience, float maxExperience)
    {
        _levelText.text = currentLvl.ToString();
        _fillExp = currentExperience / maxExperience;
    }

    private void Update()
    {
        if (_expBar.fillAmount <= _fillExp && _fillExp != 0)
            _expBar.fillAmount += _fillExp * Time.deltaTime;
        else if (_expBar.fillAmount == 1)
            _expBar.fillAmount = 0;
    }
}