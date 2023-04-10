using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowInABottleItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<Shooting>(out var playerShooting))
        {
            playerShooting.BulletSize.SetBonus(playerShooting.BulletSize.GetValue() / 10 * item.amount);
        }
    }
}