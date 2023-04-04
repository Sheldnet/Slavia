using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public ControlType controlType;

    public bool isDead = false;

    public float FinalDamage;
    public float FinalBulletSpeed;
    public float FinalRange;
    public float FinalItemPickupRange;
    [SerializeField] private float ItemPickupRangeRadius;
    [SerializeField] private float ItemPickupRangeMul;

    [SerializeField] private float DamageReduction;

    public GameObject ItemPickupRange;
    //public float xMaxborder;
    //public float xMinborder;
    //public float yMaxborder;
    //public float yMinborder;

    //[SerializeField] private float AttackSpeed;
    //[SerializeField] private float AttackSpeedMul;

    private Inventory inventory;

    [SerializeField] private float padding = 0.5f;

    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private UI_Stats uiStats;

    public enum ControlType
    { PC, Android }

    private PlayerStats _playerStats;
    private PlayerMovement _playerMovement;
    private Shooting _shooting;
    //private void moveBrorders()
    //{
    //    Camera gameCamera = Camera.main;
    //    xMinborder = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
    //    xMaxborder = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    //    yMinborder = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
    //    yMaxborder = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<ItemWorld>(out ItemWorld itemWorld))
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
        switch (collider.tag)
        {
            case "ExpOrb":
                if (collider != null)
                {
                    _playerStats.TakeExperience(_playerStats.FinalExp);
                    Destroy(collider.gameObject);
                }
                break;

            case "GoldOrb":
                if (collider != null)
                {
                    _playerStats.TakeGold(_playerStats.FinalGold);
                    Destroy(collider.gameObject);
                }
                break;
        }
    }

    private void Start() //Исходные статы
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerMovement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<Shooting>();

        switch (PlayerPrefs.GetInt("GunType"))
        {
            case (1): //Обычный выстрел
                _playerStats.BulletSpeed.SetMultiplier(1);
                _playerStats.Damage.SetMultiplier(1);
                _playerStats.AttackSpeed.SetMultiplier(1);
                break;

            case (2): //Мощный выстрел
                _playerStats.BulletSpeed.SetMultiplier(2);
                _playerStats.Damage.SetMultiplier(2);
                _playerStats.AttackSpeed.SetMultiplier(0.5f);
                _playerStats.Range.SetMultiplier(2);
                break;

            case (3): //Короткий выстрел
                _playerStats.BulletSpeed.SetMultiplier(1);
                _playerStats.Damage.SetMultiplier(0.5f);
                _playerStats.AttackSpeed.SetMultiplier(2);
                _playerStats.Range.SetMultiplier(0.5f);
                break;

            default: //Дефолт, обычный выстрел
                _playerStats.BulletSpeed.SetMultiplier(1);
                _playerStats.Damage.SetMultiplier(1);
                _playerStats.AttackSpeed.SetMultiplier(1);
                break;
        }

        // Bullet.gameObject.transform.localScale = new Vector3(6, 6, 1);

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        float BonusMoveSpeed = 0;
        float BonusDamage = 0;
        float BonusAttackSpeed = 0;

        float BonusBulletSpeed = 0;
        float BonusRange = 0;
        float BonusMaxHealth = 0;
        float BonusAttackSize = 0;
        float BonusItemPickupRange = 0;

        //Fire opal, sand clock, magic book, lucky coin
        float BonusGold = 0;
        float BonusExp = 0;
        float BonusHealth = 0;
        foreach (Item item in inventory.GetItemList())
        {
            switch (item.itemType)
            {
                default:
                case Item.ItemType.Apple:
                    {
                        BonusDamage = _playerStats.Damage.GetValue() / 10f * item.amount;
                    }
                    break;

                case Item.ItemType.BullHeart:
                    {
                        BonusMaxHealth = _playerStats.MaxHealth / 5f * item.amount;
                    }
                    break;

                case Item.ItemType.ShadowInABottle:
                    {
                        BonusAttackSize = 6f / 10f * item.amount;
                    }
                    break;

                case Item.ItemType.BirchLeaves:
                    {
                        BonusBulletSpeed = _playerStats.BulletSpeed.GetValue() / 10f * item.amount;
                    }
                    break; //10
                case Item.ItemType.SnakeSkin:
                    {
                        DamageReduction = 2 * item.amount;
                    }
                    break;

                case Item.ItemType.PigeonFeather:
                    {
                        BonusMoveSpeed = _playerMovement.MoveSpeed.GetValue() / 10f * item.amount;
                    }
                    break;

                case Item.ItemType.Magnet:
                    {
                        BonusItemPickupRange = ItemPickupRangeRadius * ItemPickupRangeMul / 10f * item.amount;
                    }
                    break;

                case Item.ItemType.LuckyCoin:
                    {
                        if (_playerStats.GoldFromOrb * (_playerStats.GoldFactor * item.amount + 1) > BonusGold)
                            BonusGold = _playerStats.GoldFromOrb * (_playerStats.GoldFactor * item.amount + 1);
                        _playerStats.FinalGold = BonusGold;
                    }
                    break;

                case Item.ItemType.MagicBook:
                    {
                        if (_playerStats.ExperienceFromOrb * (_playerStats.ExperienceFactor * item.amount + 1) != BonusExp)
                            BonusExp = _playerStats.ExperienceFromOrb * (_playerStats.ExperienceFactor * item.amount + 1);
                        _playerStats.FinalExp = BonusExp;
                    }
                    break;

                case Item.ItemType.FireOpal:
                    {
                        BonusHealth = _playerStats.healthFactor * item.amount;
                    }
                    break;
            }
        }

        //Bullet.gameObject.transform.localScale = new Vector2(6 + BonusAttackSize, 6 + BonusAttackSize);
        _playerStats.TakeDamage(-BonusHealth);
        _playerStats.MaxHealth = 6 + BonusMaxHealth;

        _playerStats.Damage.SetBonus(BonusDamage);
        _playerStats.Damage.SetBonus(BonusBulletSpeed);
        _playerMovement.MoveSpeed.SetBonus(BonusMoveSpeed);

        //Конечная скорость атаки

        FinalDamage = _playerStats.Damage.GetValue(); //Конечный урон
        FinalBulletSpeed = _playerStats.BulletSpeed.GetValue(); //Конечная скорость полета пули
        FinalRange = _playerStats.Range.GetValue(); //Конечная дальность атаки
                                                    //Эти значения не передаются в пули СЕЙЧАС
        FinalItemPickupRange = ItemPickupRangeRadius * ItemPickupRangeMul + BonusItemPickupRange;

        ItemPickupRange.GetComponent<CircleCollider2D>().radius = FinalItemPickupRange;

        uiStats.SetStats(_playerMovement.MoveSpeed.GetValue(), FinalDamage, _shooting.AttackCD, FinalBulletSpeed, FinalRange, _shooting.CurrentBullet.transform.localScale.x, _playerStats.MaxHealth, DamageReduction, FinalItemPickupRange);

        //Ввод пользователя для управления и стрельбы

        //Стрельба
    }

    //if (collider.CompareTag("PassiveItem")) {
    //    ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
    //    if (itemWorld != null) {
    //        inventory.AddItem(itemWorld.GetItem());
    //        itemWorld.DestroySelf();
    //    }
    //}
    //else if (collider.CompareTag("ExpOrb")) {
    //    if (collider != null) {
    //        experience += expFromOrb;
    //        Destroy(collider.gameObject);
    //    }
    //}
}