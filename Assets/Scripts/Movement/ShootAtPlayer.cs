using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public Transform target;

    public float rotateSpeed = 20f;

    public float speed = 0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 direction = (Vector2)target?.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = rotateAmount * rotateSpeed;

        rb.linearVelocity = transform.up * speed;
    }

}
