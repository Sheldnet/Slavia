using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBookItem : MonoBehaviour, IItem
{
    public void BuffUnit(Item item, GameObject player)
    {
        if (player.TryGetComponent<ExperienceSystem>(out ExperienceSystem playerExperience))
        {
            Debug.Log("aaa");
            playerExperience.BuffExperience(item);
        }
    }
}