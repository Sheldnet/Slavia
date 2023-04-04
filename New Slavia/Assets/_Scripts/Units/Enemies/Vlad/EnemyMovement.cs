using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float speed;
    private Rigidbody2D _enemyRb;

    private Vector2 _movingDirection;
    private Transform _playerEdgePoint;
    private Vector2 _lastMovingDirection;

    [SerializeField] private float smoothTime;
    private Vector2 currentVelocity;

    [SerializeField] private float minDistance;

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
        if (transform.position.x > _playerTransform.position.x)
        {
            _movingDirection = _playerTransform.position - transform.position;
            if (transform.position.x > _playerEdgePoint.position.x)
            {
                _lastMovingDirection = _movingDirection;
            }
        }
        else
        {
            _movingDirection = Vector2.SmoothDamp(_movingDirection, _lastMovingDirection, ref currentVelocity, smoothTime);
        }
    }

    private void FixedUpdate()
    {
        //_enemyRb.velocity = Vector3.ClampMagnitude(_movingDirection.normalized * speed, 10);

        _enemyRb.velocity = _movingDirection.normalized * speed;
        //Debug.Log(_movingDirection);
        //Debug.Log(_movingDirection.normalized);
        //Debug.Log(_enemyRb.velocity);
        //Debug.Log(_enemyRb.velocity.normalized);
        // Debug.Log(_enemyRb.velocity.magnitude);
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