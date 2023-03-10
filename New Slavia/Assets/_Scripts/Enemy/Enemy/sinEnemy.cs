using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinEnemy : MonoBehaviour
{
    public float amplitude = 2;
    public float frequency = 0.5f;

    float sinCenterY;

    public float heal;
    public float speed = 2;

    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;

    public bool inverted = false;
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;

        if (inverted)
        {
            sin *= -1;
        }

        pos.y = sinCenterY + sin;

        velocity = direction * speed;

        pos -= velocity * Time.deltaTime;

        if (transform.position.x <= -10) pos += new Vector2(20, 0);

        transform.position = pos;
    }

    public void HealCheck()
    {
        heal=heal-GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().finalDamage;
        if (heal <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                HealCheck();
                Destroy(collision.gameObject);
                break;
            case "Enemy":
                break;
            case "Player":
                GameObject.Find("Player").GetComponent<Player>().currentHealth--;
                Destroy(gameObject);
                break;
        }
    }
}
