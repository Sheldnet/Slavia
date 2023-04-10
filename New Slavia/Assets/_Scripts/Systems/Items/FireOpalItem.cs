using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOpalItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out var playerStats))
        {
            playerStats.TakeDamage(-playerStats.healthFactor * item.amount);
        }
    }
}