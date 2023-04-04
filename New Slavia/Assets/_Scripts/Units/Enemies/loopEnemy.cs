using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopEnemy : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.position.x <= -10) transform.position = new Vector3(10, transform.position.y, 0);
        if (transform.position.y <= -6) transform.position = new Vector3(transform.position.x, 5, 0);
        if (transform.position.y >= 6) transform.position = new Vector3(transform.position.x, -5, 0);
    }
}
