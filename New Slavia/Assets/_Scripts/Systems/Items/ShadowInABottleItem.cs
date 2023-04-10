using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowInABottleItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<PlayerStats>(out var playerStats))
        {
            Debug.Log("врн декюрэ я пюглепнл оскх");
        }
    }
}