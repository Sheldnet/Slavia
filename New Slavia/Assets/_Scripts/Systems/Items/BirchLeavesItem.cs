using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirchLeavesItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out var playerStats))
        {
            playerStats.BulletSpeed.SetBonus(playerStats.BulletSpeed.GetValue() / 10f * item.amount);
        }
    }
}