using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    private IItem _item;

    private void Awake()
    {
        _item = GetComponent<IItem>();
        ItemWorld.SpawnItemWorld(transform.position, item, _item);
        // Destroy(gameObject);
    }
}