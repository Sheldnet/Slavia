using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAim : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 2;
    private bool hasReal;
    public bool isEnemy = false;

    public Transform player;
    public Vector2 target;

    private void Start()
    {
        hasReal = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        hasReal = false;
        Destroy(this.gameObject);
    }

    private void OnBecameVisible()
    {
        hasReal = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(1);
            playerStats.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}