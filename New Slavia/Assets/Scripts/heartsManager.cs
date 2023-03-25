using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class heartsManager : MonoBehaviour
{
    public Player pl;
    public Image healtBar;
    public float fillHeal;
    public float velocityDmg;
    public float velocityHeal;

    public Image expBar;
    public TMP_Text levelText;
    public float fillExp;
    public float velocityExp;

    void Start()
    {        
        fillHeal = 1f;
        velocityDmg = 0.1f;
        velocityHeal = 0.1f;

        fillExp = 0f;
        velocityExp = 0.1f;

    }

    void FixedUpdate()
    {
        healMan();
        expMan();
        goldMan();

    }

    public void healMan()
    {
        fillHeal = pl.health / pl.maxHealth;
        if (healtBar.fillAmount >= fillHeal)
            healtBar.fillAmount -= velocityDmg * Time.deltaTime;
        else if (healtBar.fillAmount <= fillHeal)
            healtBar.fillAmount += velocityDmg * Time.deltaTime;
    }
    public void expMan()
    {
        levelText.text = pl.level.ToString();
        fillExp = pl.experience / pl.maxExp;
        if (expBar.fillAmount <= fillExp && fillExp != 0)
            expBar.fillAmount += fillExp * Time.deltaTime;
        else if (expBar.fillAmount == 1)
            expBar.fillAmount = 0;
    }
    public void goldMan()
    {

    }

}
