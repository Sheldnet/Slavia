using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wickedCreat : MonoBehaviour
{
    public float heal;
    public gunAim gunLay;

    //public Transform teleportUp;
    //public Transform teleportDown;
    //public Transform teleportOrigin;

    private bool hasReal;
    public float speed = 0;

    //public float teleportDelay = 0f;
    //public float movingDelay = 0f;

    //float teleportTimer = 0f;
    //float movingTimer = 0f;
    //string upDown = "middle";
    //bool isMoving = true;

    //Vector2 up, down, middle;
    private float sizeX;

    private float sizeY;
    public BoxCollider2D goCol;
    private float recSizeX;
    private float recSizeY;
    private Vector3 final;
    private bool target = false;

    private void Start()
    {
        hasReal = true;
        sizeX = goCol.size.x / 2;
        sizeY = goCol.size.y / 2;
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        if (target)
            this.transform.position = Vector3.MoveTowards(this.transform.position, final, 2f * speed * Time.deltaTime);

        //if (movingTimer > movingDelay && isMoving)
        //{
        //    down = teleportDown.transform.position;
        //    up = teleportUp.transform.position;
        //    middle = teleportOrigin.transform.position;
        //    isMoving = false;
        //    speed = 0;
        //    gunLay.autoShoot = true;
        //}
        //else
        //{
        //    movingTimer += Time.deltaTime;
        //    this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        //}

        //if (teleportTimer >= teleportDelay && gunLay.autoShoot)
        //{
        //    gunLay.autoShoot = false;
        //    Teleport();
        //    teleportTimer = 0;
        //}
        //else
        //{
        //    teleportTimer += Time.deltaTime;
        //}
        //if (!hasReal)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            recSizeX = collision.gameObject.transform.localScale.x / 2;
            recSizeY = collision.gameObject.transform.localScale.y / 2;

            float maxX = collision.gameObject.transform.position.x + recSizeX - sizeX;
            float minX = collision.gameObject.transform.position.x - recSizeX + sizeX;
            float maxY = collision.gameObject.transform.position.y + recSizeY - sizeY;
            float minY = collision.gameObject.transform.position.y - recSizeY + sizeY;
            Debug.Log(" xX =" + maxX + " nX =" + minX + " xY =" + maxY + " ny =" + minY);
            final = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            Debug.Log(final);
            target = true;
        }
        else if (collision.gameObject.tag != "Enemy")
        {
            if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
            {
                heal -= playerStats.Damage.GetValue();
                if (heal <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    //public void HealCheck()
    //{
    //    heal = heal - GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().finalDamage;
    //    if (heal <= 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    private void OnBecameInvisible()
    {
        hasReal = false;
    }

    private void OnBecameVisible()
    {
        hasReal = true;
    }
}