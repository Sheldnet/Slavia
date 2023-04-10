using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullHeartItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out var playerStats))
        {
            playerStats.MaxHealth += playerStats.MaxHealth / 5f * item.amount;
        }
    }
}