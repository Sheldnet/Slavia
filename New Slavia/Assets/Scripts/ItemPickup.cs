using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float itemSpeed = 1f;
    //private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        //inventory = GetComponentInParent<Player>().inventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.CompareTag("PassiveItem") || collider.CompareTag("ExpOrb")) {
            if (collider != null) {
                //Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                //Vector2 direction = collider.transform.position - transform.position;
                //direction.Normalize();
                //rb.MovePosition((Vector2)transform.position + direction * Time.deltaTime * itemSpeed);
                collider.transform.position = Vector2.MoveTowards(collider.transform.position, transform.position, Time.deltaTime * itemSpeed);
            }
        }
    }
}
