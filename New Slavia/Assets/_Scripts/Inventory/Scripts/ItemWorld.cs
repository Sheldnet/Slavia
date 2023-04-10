using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private IItem _item_V;

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item, IItem item_V)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.InitializeItemWorld(item, item_V);

        return itemWorld;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InitializeItemWorld(Item item, IItem item_V)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        this._item_V = item_V;
    }

    public Item GetItem()
    {
        return item;
    }

    public IItem GetBuff()
    {
        return _item_V;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}