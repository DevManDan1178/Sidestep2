using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletPointer : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletDirectionPosition;
    private Vector3 bulletDirection;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float bulletForce = 15f;
    public float timeBeforeFiring = 0f;



    // Update is called once per frame
    void Start()
    {
        if (bulletDirectionPosition == null)
        {
           bulletDirectionPosition = GameObject.Find("Bullet Direction"); 
        }
    }
    void FixedUpdate()
    {   
        timeBeforeFiring -= Time.deltaTime;
        if (timeBeforeFiring <= 0)
        {
        
        bulletDirection = bulletDirectionPosition.transform.position;
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
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletInstance.AddComponent<Rigidbody2D>();
            bulletInstance.GetComponent<Rigidbody2D>().gravityScale = 0f;
            bulletInstance.GetComponent<Rigidbody2D>().angularDamping = 0f;
            bulletInstance.GetComponent<Rigidbody2D>().linearDamping = 0f;
            bulletInstance.GetComponent<Rigidbody2D>().AddForce((bulletDirection - transform.position) * bulletForce * 10);
            
        }
}
    }
}
