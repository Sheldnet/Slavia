using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    [HideInInspector] public Bullet CurrentBullet;

    [SerializeField] private Bullet _bulletSmall;
    [SerializeField] private Bullet _bulletMedium;
    [SerializeField] private Bullet _bulletLarge;

    private ObjectPool<Bullet> _bulletPool;

    [SerializeField] public float AttackCD;
    private float _currentAttackCooldown;

    [SerializeField] private Transform _shotPoint;

    private PlayerInput _playerInput;
    private PlayerStats _playerStats;
    private PlayerStatsController _playerStatsController;

    public Stat BulletSize;

    // Start is called before the first frame update
    private void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerInput = GetComponent<PlayerInput>();
        _playerStatsController = GetComponent<PlayerStatsController>();

        _bulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet, BackBulletToPool, DestoyBullet, false, 10, 30);

        switch (PlayerPrefs.GetInt("GunType"))
        {
            case (1):
                CurrentBullet = _bulletSmall;
                break;

            case (2):
                CurrentBullet = _bulletMedium;
                break;

            case (3):
                CurrentBullet = _bulletLarge;
                break;

            default:
                CurrentBullet = _bulletSmall;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        AttackCD = 1 / (_playerStats.AttackSpeed.GetValue());
        if (_currentAttackCooldown <= 0)
        {
            _bulletPool.Get();
            _currentAttackCooldown = 1 / AttackCD;
        }
        else
        {
            _currentAttackCooldown -= Time.deltaTime;
        }
    }

    private Bullet CreateBullet()
    {
        return Instantiate(CurrentBullet);
    }

    private void GetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _shotPoint.position;
        bullet.transform.rotation = Quaternion.AngleAxis(_playerInput.LookDirection, Vector3.forward);
        bullet.Initialize(_playerStats.Damage.GetValue(),
                _playerStats.BulletSpeed.GetValue(), _playerStats.AttackRange.GetValue(), BulletSize.GetValue(), this._bulletPool);
    }

    private void BackBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void DestoyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}