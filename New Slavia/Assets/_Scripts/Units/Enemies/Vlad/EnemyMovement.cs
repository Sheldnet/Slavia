using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float _Speed;
    [SerializeField] private float _Force;
    private Rigidbody2D _enemyRb;

    private Vector2 _movingDirection;
    private Transform _playerEdgePoint;
    private Vector2 _lastMovingDirection;

    [SerializeField] private float _ReppeledTime;
    private Vector2 currentVelocity;

    [SerializeField] private float minDistance;

    private bool isReppeled = false;
    [SerializeField] private float _SmoothTime = 0.3f;

    // Start is called before the first frame update
    private void Start()
    {
        _playerTransform = GameManager.Instance.Player.transform;
        _playerEdgePoint = _playerTransform.GetChild(1);
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x >= _playerTransform.position.x)
        {
            _movingDirection = _playerTransform.position - transform.position;
            if (transform.position.x > _playerEdgePoint.position.x)
            {
                _lastMovingDirection = _movingDirection;
            }
        }
        else
        {
            _movingDirection = Vector2.SmoothDamp(_movingDirection, _lastMovingDirection, ref currentVelocity, _SmoothTime);
        }
    }

    private void FixedUpdate()
    {
        //Первый способ
        if (!isReppeled)
            _enemyRb.velocity = _movingDirection.normalized * _Speed;

        //Второй способ
        //Vector2 desiredVelocity = _movingDirection.normalized * _Speed;
        //Vector2 deltaVelocity = desiredVelocity - _enemyRb.velocity;
        //Vector2 moveForce = deltaVelocity * (_Force * Time.fixedDeltaTime);
        //_enemyRb.AddForce(moveForce);

        //3 sposob
        //_enemyRb.MovePosition((Vector2)transform.position + (_movingDirection.normalized * _Speed * Time.deltaTime));
    }

    public IEnumerator TakeImpulse(Vector2 force)
    {
        isReppeled = true;
        _enemyRb.velocity = Vector2.zero;
        _enemyRb.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_ReppeledTime);

        isReppeled = false;
    }

    private void OnDrawGizmos()
    {
        if (_playerTransform != null)
        {
            //Gizmos.color = Color.green;
            //Gizmos.DrawLine(transform.position, _targetTransform.position);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, _movingDirection);
            //Gizmos.color = Color.blue;
            //Gizmos.DrawRay(transform.position, _lastMovingDirection);
            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, _enemyRb.velocity);
        }
    }
}