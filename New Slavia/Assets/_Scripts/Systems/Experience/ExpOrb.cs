using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float scatterForce;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OrbScatter();
    }

    private void OrbScatter()
    {
        Vector2 direction = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
        rb.AddForce(direction * scatterForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ExperienceSystem>(out ExperienceSystem playerExperience))
        {
            playerExperience.TakeExperience();
            Destroy(this.gameObject);
        }
    }
}