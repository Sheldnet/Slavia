using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCoinItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent(out MoneySystem playerGold))
        {
            playerGold.BuffGold(item); //Пофиксить чтоб сбрасывало это значение
        }
    }
}