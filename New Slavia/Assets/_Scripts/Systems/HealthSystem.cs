using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    //public Image[] hearts;
    //public Sprite fullHeart;
    //public Sprite halfHeart;
    //public Sprite emptyHeart;
    public Image healtBar;

    public float fillHeal;
    public float velocityDmg;
    public float velocityHeal;

    public Image expBar;
    public TMP_Text levelText;
    public float fillExp;
    public float velocityExp;

    public TMP_Text goldText;
    public float velocityGold;

    //private void FixedUpdate()
    //{
    //    foreach (Image img in hearts)
    //    {
    //        img.sprite = emptyHeart;
    //    }

    //    for (int i = 0; i < _playerStats.GetCurrentHealth(); i++)
    //    {
    //        if (i % 2 == 0)
    //        {
    //            hearts[i].sprite = fullHeart;
    //        }
    //        else
    //        {
    //            hearts[i].sprite = halfHeart;
    //        }
    //    }
    //}
    private void Start()
    {
        fillHeal = 1f;
        velocityDmg = 0.1f;
        velocityHeal = 0.1f;

        fillExp = 0f;
        velocityExp = 0.1f;
    }

    private void FixedUpdate()
    {
        healMan();
        expMan();
        goldMan();
    }

    public void healMan()
    {
        fillHeal = _playerStats.GetCurrentHealth() / _playerStats.MaxHealth;
        if (healtBar.fillAmount > fillHeal)
            healtBar.fillAmount -= velocityDmg * Time.deltaTime;
        else if (healtBar.fillAmount <= fillHeal)
            healtBar.fillAmount += velocityDmg * Time.deltaTime;
    }

    public void expMan()
    {
        levelText.text = _playerStats.Level.ToString();
        fillExp = _playerStats.CurrentExperience / _playerStats.MaxExperience;
        if (expBar.fillAmount <= fillExp && fillExp != 0)
            expBar.fillAmount += fillExp * Time.deltaTime;
        else if (expBar.fillAmount == 1)
            expBar.fillAmount = 0;
    }

    public void goldMan()
    {
        goldText.text = _playerStats.CurrentGold.ToString();
    }
}