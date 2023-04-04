using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAim : MonoBehaviour
{
    public bulletAim bullet;
    Vector2 direction;

    bool upDown = false;
    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;


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
        bulletAim goBullet = go.GetComponent<bulletAim>();
        goBullet.direction = direction;
    }
}
