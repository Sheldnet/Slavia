using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotate : MonoBehaviour
{
    public bullet bullet;
    Vector2 direction;

    bool upDown = false;
    public bool autoShoot = false;
    public float rotation = 0f;
    public float shootIntervalSeconds = 0.5f;

    float shootTimer = 0f;
    public float shootDelaySeconds = 0.0f;
    float delayTimer = 0f;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        direction = (transform.localRotation * Vector2.up).normalized;

        if (this.gameObject.transform.rotation == Quaternion.Euler(0f, 0f, 30f))
        {
            upDown = true;
        }
        else if (this.gameObject.transform.rotation == Quaternion.Euler(0f, 0f, -30f))
        {
            upDown = false;
        }

        if (autoShoot)
        {
            //if(delayTimer>=shootDelaySeconds)
            //{
                if(shootTimer>=shootIntervalSeconds)
                {
                    autoShoot = false;
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

        if(!upDown)
        {
            this.gameObject.transform.Rotate(0f, 0f, rotation);
            autoShoot = true;
        }
        else
        {
            this.gameObject.transform.Rotate(0f, 0f, -rotation);
            autoShoot = true;
        }
        

    }
}
