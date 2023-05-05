using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandatBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.TryGetComponent<EnemyMovement>(out EnemyMovement enemyMovement))
        {
            StartCoroutine(enemyMovement.TakeImpulse(_pushForce * transform.right));
            Debug.Log("Прикладываю " + _pushForce + " к " + collision.name);
        }
    }

    public override void Move()
    {
        base.Move();
        _rb.velocity = _speed * transform.right;
    }
}