using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAimButtton : MonoBehaviour
{
    public GameObject rightStick;
    public GameObject spriteTurn;
    private Bullet bullet;
    private Weaphone _shooting;


    void Start()
    {
        bullet = GetComponentInParent<Bullet>();
        _shooting = GetComponentInParent<Weaphone>();
        
    }
    public void OnButtonPress()
    {
        if (_shooting.autoShoot == false)
        {
            _shooting.autoShoot = true;
            this.GetComponent<Collider2D>().enabled = true;
            spriteTurn.SetActive(true);
            rightStick.SetActive(false);
        }
        else
        {
            _shooting.autoShoot = false;
            this.GetComponent<Collider2D>().enabled = false;
            spriteTurn.SetActive(false);
            rightStick.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Start enter");
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            _shooting.autoshoting = true;
            if (collider != null)
            {
                Debug.Log("Start stay");

                Vector2 targetDir = collider.transform.position - transform.position;
                float sign = (collider.transform.position.y < transform.position.y) ? -1.0f : 1.0f;

                float angleRotate = Vector2.Angle(Vector2.right, targetDir) * sign;
                Debug.Log("stay 1 " + angleRotate);
                _shooting.angleAuto = angleRotate;
                Debug.Log("stay" + angleRotate);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
           _shooting.autoshoting = false;
            _shooting.angleAuto = 0;
        }
    }
}
