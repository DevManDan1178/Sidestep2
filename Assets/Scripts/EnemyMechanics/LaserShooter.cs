using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public Transform firePoint;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public LineRenderer lineRenderer2;
    public int damage;
    public LineRenderer warningLaser;
    public LineRenderer warningLaser2;
   

    private void Start() {
        lineRenderer.enabled = false;
        lineRenderer2.enabled = false;
        warningLaser.enabled = false;
        warningLaser2.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateRendererPositions();
        StartCoroutine(Shoot());
    }

    private void UpdateRendererPositions()
    {
        warningLaser.SetPosition(0, firePoint.position);
        warningLaser.SetPosition(1, firePoint.position + firePoint.up * 4000);
        warningLaser2.SetPosition(0, firePoint.position);
        warningLaser2.SetPosition(1, firePoint.position + firePoint.up * -4000);

                    
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 4000);
        lineRenderer2.SetPosition(0, firePoint.position);
        lineRenderer2.SetPosition(1, firePoint.position + firePoint.up * -4000);
    }
    IEnumerator Shoot ()
    {

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if (canFire == true)
        {
            warningLaser.enabled = false;
            warningLaser2.enabled = false;
            lineRenderer.enabled = true;
            lineRenderer2.enabled = true;
            canFire = false;
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up * -4000);
            RaycastHit2D hitInfo2 = Physics2D.Raycast(firePoint.position, firePoint.up * 4000);

            if (hitInfo)
            {
                Player player = hitInfo.transform.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }

                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            }
                
            if (hitInfo2)
            {
                Player player = hitInfo2.transform.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }

                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            }  

            yield return new WaitForSeconds(0.15f);
            lineRenderer.enabled = false;
            lineRenderer2.enabled = false;
            warningLaser.enabled = true;
            warningLaser2.enabled = true;
        }


    }
}
