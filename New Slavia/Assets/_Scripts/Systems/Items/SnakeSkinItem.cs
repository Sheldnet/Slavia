using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSkinItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out var playerStats))
        {
            playerStats.DamageReduction = 2 * item.amount;
        }
    }
}