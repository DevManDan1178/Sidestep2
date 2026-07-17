using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletShooter : MonoBehaviour
{
  
    public GameObject bullet;
    public Transform bulletPointer;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
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


        if (canFire == true)
        {
            canFire = false;
            Instantiate(bullet, bulletPointer.position, Quaternion.identity);
        }
    }
}