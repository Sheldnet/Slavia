using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed;
    public int startPoint;
    public Transform[] points;
    Vector2[] upDown = new Vector2[3];

    private int i;

    void Start()
    {
        transform.position = points[startPoint].position;
        upDown[0] = points[0].position;
        upDown[1] = points[1].position;
        upDown[2] = points[2].position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, upDown[i]) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, upDown[i], speed * Time.deltaTime);
    }
}
