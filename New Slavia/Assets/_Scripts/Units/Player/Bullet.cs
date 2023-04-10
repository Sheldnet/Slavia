using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _Damage;
    [SerializeField] private float _Speed;
    [SerializeField] private float _Range;

    private Vector3 _startPos;
    private Rigidbody2D _rb;
    private ObjectPool<Bullet> _ownerPool;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float damage, float speed, float range, float size, ObjectPool<Bullet> ownerObjectPool)
    {
        _Damage = damage;
        _Speed = speed;
        _Range = range;
        _startPos = transform.position;
        _ownerPool = ownerObjectPool;

        _rb.velocity = _Speed * transform.right;
    }

    private void Update()
    {
        if (Mathf.Abs(Vector3.Distance(_startPos, transform.position)) >= _Range)
        {
            DestroyBullet();//Уничтожение по достижению макс расстояния полета
        }
    }

    private void DestroyBullet()
    {
        _ownerPool.Release(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
        {
            enemyStats.TakeDamage(_Damage);
        }
        DestroyBullet();
    }
}