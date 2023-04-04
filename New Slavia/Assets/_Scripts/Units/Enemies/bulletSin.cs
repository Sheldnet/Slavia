using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSin : MonoBehaviour
{
    private bool hasReal;

    float sinCenterY;
    public float amplitude = 2;
    public float frequency = 0.5f;
    void Start()
    {
        hasReal = true;
        sinCenterY = transform.position.y;
    }


    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;

        pos.y = sinCenterY + sin;
        transform.position = pos;
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
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
