using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLaser : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public bool autoShoot;

    private void Start()
    {
        lineRenderer.enabled = false;
    }
    private void FixedUpdate()
    {
        if(autoShoot)
        {
            StartCoroutine(Shoot());
            autoShoot = false;
        }        
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
        if(hitInfo)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);

        }
        
        lineRenderer.enabled = true;

        //yield return 0;
        yield return new WaitForSeconds(5f);

        lineRenderer.enabled = false;
    }

}
