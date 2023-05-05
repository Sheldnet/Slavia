using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private float _damage;
    protected float _speed;
    private float _range;

    private float _numberOfPiercings = 1;

    private Vector3 _startPos;
    protected Rigidbody2D _rb;
    private ObjectPool<Bullet> _ownerPool;

    protected float _pushForce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float damage, float speed, float range, float size, float pushForce, float numberOfPiercings, ObjectPool<Bullet> ownerObjectPool)
    {
        _damage = damage;
        _speed = speed;
        _range = range;
        _pushForce = pushForce;
        _numberOfPiercings = numberOfPiercings;

        _startPos = transform.position;
        _ownerPool = ownerObjectPool;

        transform.localScale = new Vector3(size, size, 1);
    }

    private void Update()
    {
        if (Mathf.Abs(Vector3.Distance(_startPos, transform.position)) >= _range)
        {
            DestroyBullet();//Уничтожение по достижению макс расстояния полета
        }
    }

    private void DestroyBullet()
    {
        _ownerPool.Release(this);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
        {
            enemyStats.TakeDamage(_damage);
            Debug.Log("Наношу " + _damage + " урона по " + collision.name);
            if (_numberOfPiercings > 0)
            {
                _numberOfPiercings--;
            }
            else
            {
                DestroyBullet();
            }
        }
    }

    public virtual void Move()
    {
    }
}