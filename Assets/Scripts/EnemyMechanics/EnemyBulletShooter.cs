using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletShooter : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;


    // Update is called once per frame
    void FixedUpdate()
    {

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if (canFire)
        {
            canFire = false;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
