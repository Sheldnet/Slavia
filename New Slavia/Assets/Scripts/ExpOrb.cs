using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float scatterForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OrbScatter();
    }

    void OrbScatter() {
        Vector2 direction = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
        rb.AddForce(direction * scatterForce, ForceMode2D.Impulse);
    }
}
