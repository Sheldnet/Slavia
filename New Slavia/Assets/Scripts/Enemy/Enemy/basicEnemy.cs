using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public float heal;
    private bool hasReal;
    public float speed = 2;
    public bool loop =false;
    public float dmg;
    public float exp;
    public float gold;

    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;

    [SerializeField] GameObject expOrbPrefab;
    [SerializeField] GameObject goldOrbPrefab;


    void Start()
    {
       hasReal = true;
    }


    void FixedUpdate()
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
        heal = heal - GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().FinalDamage;
        if (heal <= 0)
        {
            //GameObject.Find("Player").GetComponent<Player>().experience += exp;
            for (int i = 0; i < exp; i += 5) {
                Instantiate(expOrbPrefab, transform.position, Quaternion.identity);
                Instantiate(goldOrbPrefab, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Bullet":
                HealCheck();
                Destroy(collision.gameObject);
                break;
            case "Enemy":
                break;
            case "Player":
                GameObject.Find("Player").GetComponent<Player>().health -= dmg;                
                Destroy(this.gameObject);
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
