using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaVisp : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    public GameObject visp;
    public float heal;
    public float speed = 2;
    private Vector2 upLeft, upRight, downLeft, downRight;

    public Vector2 direction = new Vector2(1, 0);

    public Vector2 velocity;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        velocity = direction * speed;
        Vector2 pos = transform.position;
        pos -= velocity * Time.deltaTime;
        transform.position = pos;
        if (transform.position.x <= -10) transform.position = new Vector3(10, transform.position.y, 0);
        if (transform.position.y <= -6) transform.position = new Vector3(transform.position.x, 5, 0);
        if (transform.position.y >= 6) transform.position = new Vector3(transform.position.x, -5, 0);
    }

    public void separateVisps()
    {
        upLeft = this.transform.position + new Vector3(-0.14f, 0.14f, 0f);
        upRight = this.transform.position + new Vector3(0.14f, 0.14f, 0f);
        downLeft = this.transform.position + new Vector3(-0.14f, -0.14f, 0f);
        downRight = this.transform.position + new Vector3(0.14f, -0.14f, 0f);

        GameObject vis1 = Instantiate(visp, upLeft, Quaternion.Euler(0, 0, 45));
        GameObject vis2 = Instantiate(visp, upRight, Quaternion.Euler(0, 0, 135));
        GameObject vis3 = Instantiate(visp, downLeft, Quaternion.Euler(0, 0, -135));
        GameObject vis4 = Instantiate(visp, downRight, Quaternion.Euler(0, 0, -45));

        vis1.GetComponent<basicEnemy>().direction = new Vector2(-1, 1);
        vis2.GetComponent<basicEnemy>().direction = new Vector2(1, 1);
        vis3.GetComponent<basicEnemy>().direction = new Vector2(-1, -1);
        vis4.GetComponent<basicEnemy>().direction = new Vector2(1, -1);

        vis1.GetComponent<basicEnemy>().loop = false;
        vis2.GetComponent<basicEnemy>().loop = false;
        vis3.GetComponent<basicEnemy>().loop = false;
        vis4.GetComponent<basicEnemy>().loop = false;
    }

    public void HealCheck()
    {
        //heal = heal - GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().finalDamage;
        //if (heal <= 0)
        //{
        //    separateVisps();
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(1);
            playerStats.TakeDamage(1);
            Destroy(gameObject);
        }
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                HealCheck();
                Destroy(collision.gameObject);
                break;
        }
    }
}