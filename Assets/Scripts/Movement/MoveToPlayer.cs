using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float speed;
    public float chaseOrOrbit;

    public float rotateSpeed;

    public Rigidbody2D rb;
    public Transform target;
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Vector2 direction = (Vector2)target.position - rb.position;
        
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
    
        rb.linearVelocity = transform.up * chaseOrOrbit* speed;

    
    }
}
