using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysLaserFixed : MonoBehaviour
{
    public Transform firePoint;
    public Transform originPoint;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public int damage;
    public LineRenderer warningLaser;
    public Vector3[] positions;

    // Update is called once per frame
    void Start()
    {
        lineRenderer.enabled = false;
    }
    void FixedUpdate()
    {
        StartCoroutine (Shoot());
        Vector3[] positions = {firePoint.position, originPoint.position};
    }

    IEnumerator Shoot ()
    {

        warningLaser.SetPositions(positions);



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
           
            lineRenderer.enabled = true;
           
            canFire = false;
            RaycastHit2D hitInfo = Physics2D.Raycast(originPoint.position, originPoint.right);
            

            if (hitInfo)
            {
                Player player = hitInfo.transform.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }

                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

                lineRenderer.SetPositions(positions);

                

  
            }
            else
            {
                lineRenderer.SetPositions(positions);

        
            }

            yield return new WaitForSeconds(0.25f);

            lineRenderer.enabled = false;
            warningLaser.enabled = true;
        }
    }
}
