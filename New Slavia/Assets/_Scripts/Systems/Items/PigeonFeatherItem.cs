using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFeatherItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.MoveSpeed.SetBonus(playerMovement.MoveSpeed.GetValue() / 10f * item.amount);
        }
    }
}