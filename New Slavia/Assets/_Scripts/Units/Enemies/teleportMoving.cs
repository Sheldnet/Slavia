using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportMoving : MonoBehaviour
{
    public float heal;
    public gunAim gunLay;

    public Transform teleportUp;
    public Transform teleportDown;
    public Transform teleportOrigin;

    private bool hasReal;
    public float speed = 0;

    public float teleportDelay = 0f;
    public float movingDelay = 0f;

    private float teleportTimer = 0f;
    private float movingTimer = 0f;
    private string upDown = "middle";
    private bool isMoving = true;

    private Vector2 up, down, middle;

    private void Start()
    {
        hasReal = true;
    }

    private void FixedUpdate()
    {
        if (movingTimer > movingDelay && isMoving)
        {
            down = teleportDown.transform.position;
            up = teleportUp.transform.position;
            middle = teleportOrigin.transform.position;
            isMoving = false;
            speed = 0;
            gunLay.autoShoot = true;
        }
        else
        {
            movingTimer += Time.deltaTime;
            this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (teleportTimer >= teleportDelay && gunLay.autoShoot)
        {
            gunLay.autoShoot = false;
            Teleport();
            teleportTimer = 0;
        }
        else
        {
            teleportTimer += Time.deltaTime;
        }
        if (!hasReal)
        {
            Destroy(gameObject);
        }
    }

    public void Teleport()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Teleport");
        Invoke("Teleport1", 0.7f);
    }

    private void Teleport1()
    {
        switch (upDown)
        {
            case "middle":
                this.gameObject.transform.position = up;
                gunLay.autoShoot = true;
                Debug.Log("mid");
                upDown = "up";
                break;

            case "up":
                this.gameObject.transform.position = down;
                gunLay.autoShoot = true;
                upDown = "down";
                Debug.Log("up");
                break;

            case "down":
                this.gameObject.transform.position = middle;
                gunLay.autoShoot = true;
                upDown = "middle";
                Debug.Log("down");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            HealCheck();
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

    private void OnBecameInvisible()
    {
        hasReal = false;
    }

    private void OnBecameVisible()
    {
        hasReal = true;
    }
}