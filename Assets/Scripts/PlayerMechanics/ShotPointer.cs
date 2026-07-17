using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointer : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePosition;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePosition - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
                
            }
            animator.SetBool("IsShooting", false);
        }


        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            animator.SetBool("IsShooting", true);
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            
        }
    }

}



