using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Weaphone : MonoBehaviour
{
    private ObjectPool<Bullet> _bulletPool;

    [SerializeField] private Bullet _Bullet;

    [SerializeField] public float AttackInterval;
    private float _currentAttackCooldown;

    [SerializeField] private Transform _shotPoint;

    protected PlayerInput _playerInput;

    [SerializeField] private float _ActiveTime;
    private float _currentActiveTime;
    [SerializeField] private float _ReloadTime;
    private float _currentCooldown;

    [SerializeField] private float _BulletsCountInShot;
    [SerializeField] private float _CritChancePercent;

    public Stat Damage;
    [SerializeField] private float BulletCritMultiplier;

    public Stat Speed;
    public Stat Range;
    public Stat BulletSize;
    public Stat PiercingCount;
    public Stat PushForce;

    public bool autoShoot;
    public bool autoshoting;
    public float angleAuto;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet, BackBulletToPool, DestoyBullet, false, 10, 30);
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (!autoShoot)
        {
            if (_currentActiveTime > 0)
            {
                if (_currentAttackCooldown <= 0)
                {
                    for (int i = 0; i < _BulletsCountInShot; i++)
                    {
                        _bulletPool.Get();
                    }

                    _currentAttackCooldown = 1 / AttackInterval;
                }
                else
                {
                    _currentAttackCooldown -= Time.deltaTime;
                }
                _currentActiveTime -= Time.deltaTime;
            }
            else
            {
                if (_currentCooldown <= 0)
                {
                    _currentActiveTime = _ActiveTime;
                    _currentCooldown = _ReloadTime;
                }
                else
                {
                    _currentCooldown -= Time.deltaTime;
                }
            }
        }
        else
        {
            if (_currentAttackCooldown <= 0 && autoshoting)
            {
                for (int i = 0; i < _BulletsCountInShot; i++)
                {
                    _bulletPool.Get();
                }

                _currentAttackCooldown = 1 / AttackInterval;
            }
            else if (autoshoting)
            {
                _currentAttackCooldown -= Time.deltaTime;
            }
            
        }

    }

    private Bullet CreateBullet()
    {
        return Instantiate(_Bullet);
    }

    protected virtual void GetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _shotPoint.position;
        _playerInput.LookDirection = angleAuto;
        bullet.transform.rotation = Quaternion.AngleAxis(_playerInput.LookDirection, Vector3.forward);
        if (Random.Range(0, 1) < _CritChancePercent / 100)
        {
            bullet.Initialize(Damage.GetValue() * BulletCritMultiplier, Speed.GetValue(), Range.GetValue(), BulletSize.GetValue(), PushForce.GetValue(), PiercingCount.GetValue(), this._bulletPool);
        }
        else
        {
            bullet.Initialize(Damage.GetValue(), Speed.GetValue(), Range.GetValue(), BulletSize.GetValue(), PushForce.GetValue(), PiercingCount.GetValue(), this._bulletPool);
        }
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