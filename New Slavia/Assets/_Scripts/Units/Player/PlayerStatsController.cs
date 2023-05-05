using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class PlayerStatsController : MonoBehaviour
{
    public ControlType controlType;

    public bool isDead = false;

    [SerializeField] private float ItemPickupRangeRadius;

    [SerializeField] private float ItemPickupRangeMul;

    public GameObject ItemPickupRange;

    private Inventory inventory;

    [SerializeField] private float padding = 0.5f;

    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private UI_Stats uiStats;

    public enum ControlType
    { PC, Android }

    private PlayerStats _playerStats;
    private PlayerMovement _playerMovement;
    private Shooting _shooting;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<ItemWorld>(out ItemWorld itemWorld))
        {
            inventory.AddItem(itemWorld.GetItem());
            Debug.Log("Столкновение");
            itemWorld.GetBuff().BuffUnit(inventory.GetItemList().FirstOrDefault(item => item.itemType == itemWorld.GetItem().itemType), _playerStats.gameObject);
            //if (itemWorld.TryGetComponent<IItem>(out IItem item))
            //{
            //    item.BuffUnit(itemWorld.GetItem(), this.gameObject);
            //}
            itemWorld.DestroySelf();
        }
    }

    private void Start() //Исходные статы
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerMovement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<Shooting>();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        uiStats.SetStats(_playerMovement.MoveSpeed.GetValue(), _playerStats.Damage.GetValue(), 1/*_shooting.AttackCD*/, _playerStats.BulletSpeed.GetValue(), _playerStats.AttackRange.GetValue(), 1/*_shooting.CurrentBullet.transform.localScale.x*/, _playerStats.MaxHealth, _playerStats.DamageReduction, _playerStats.PickUpRange.GetValue());
    }
}