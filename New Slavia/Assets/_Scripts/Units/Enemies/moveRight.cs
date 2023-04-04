using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRight : MonoBehaviour
{
    public int heal;
    private bool hasReal;
    public float speed = 2;

    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;


    void Start()
    {
       hasReal = true;
    }


    void FixedUpdate()
    {
        velocity = direction * speed;
        Vector2 pos = transform.position;
        pos -= velocity * Time.deltaTime;

        if(!hasReal)
        {
            Destroy(gameObject);
        }
        transform.position = pos;
    }

    public void HealCheck()
    {
        heal--;
        if(heal<=0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(collision.gameObject);
            HealCheck();
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
