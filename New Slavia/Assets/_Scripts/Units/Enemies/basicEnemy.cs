using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public float heal;
    private bool hasReal;
    public float speed = 2;
    public bool loop = false;

    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;

    private void Start()
    {
        hasReal = true;
    }

    private void FixedUpdate()
    {
        velocity = direction * speed;
        Vector2 pos = transform.position;
        pos -= velocity * Time.deltaTime;
        transform.position = pos;
        if (loop)
        {
            if (transform.position.x <= -10) transform.position = new Vector3(10, transform.position.y, 0);
            if (transform.position.y <= -6) transform.position = new Vector3(transform.position.x, 5, 0);
            if (transform.position.y >= 6) transform.position = new Vector3(transform.position.x, -5, 0);
        }
        else
        {
            if (!hasReal)
            {
                Destroy(gameObject);
            }
        }
    }

    public void HealCheck()
    {
        //heal = heal - GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().finalDamage;
        //if (heal <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(1);

            Destroy(gameObject);
        }

        switch (collision.gameObject.tag)
        {
            case "Bullet":
                HealCheck();
                Destroy(collision.gameObject);
                break;
        }
    }

    private void OnBecameInvisible()
    {
        hasReal = false;
    }

    private void OnBecameVisible()
    {
        hasReal = true;
    }
}