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
    }

    private void FixedUpdate()
    {
        HealMan();
    }

    public void HealMan()
    {
        fillHeal = _playerStats.GetCurrentHealth() / _playerStats.MaxHealth;
        if (healtBar.fillAmount > fillHeal)
            healtBar.fillAmount -= velocityDmg * Time.deltaTime;
        else if (healtBar.fillAmount <= fillHeal)
            healtBar.fillAmount += velocityDmg * Time.deltaTime;
    }
}