using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSimpl : MonoBehaviour
{
    public bullet bullet;
    Vector2 direction;

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;

    float shootTimer = 0f;
    //public float shootDelaySeconds = 0.0f;
    //float delayTimer = 0f;

    void Start()
    {

    }


    void FixedUpdate()
    {
        direction = (transform.localRotation * Vector2.left).normalized;

        if (autoShoot)
        {
            //if(delayTimer>=shootDelaySeconds)
            //{
            if (shootTimer >= shootIntervalSeconds)
            {
                Shoot();

                shootTimer = 0;
            }
            else
            {
                shootTimer += Time.deltaTime;
            }
            //}
            //else
            //{
            //  delayTimer += Time.deltaTime;
            //}
        }

    }
    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        bullet goBullet = go.GetComponent<bullet>();
        goBullet.direction = direction;
    }
}
