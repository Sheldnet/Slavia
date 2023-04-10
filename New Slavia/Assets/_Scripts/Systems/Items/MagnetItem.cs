using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out var playerStats))
        {
            playerStats.PickUpRange.SetBonus(playerStats.PickUpRange.GetValue() / 10f * item.amount);
            if (player.TryGetComponent(out PlayerStatsController playerStatsController))
            {
                playerStatsController.ItemPickupRange.GetComponent<CircleCollider2D>().radius = playerStats.PickUpRange.GetValue();
            }
        }
    }
}