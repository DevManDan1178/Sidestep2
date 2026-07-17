using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeyboardMovement : MonoBehaviour
{   
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    public float rotationspeed = 5f;
    public float upwardsPull;
    public float rightwardsPull;
    private Vector2 movement;
    Vector2 pull;
    public float pullSpeed;

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate() 
    {   
        pull.y = upwardsPull;
        pull.x = rightwardsPull;
        rb.SetRotation(rb.rotation + rotationspeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime + pull * pullSpeed * Time.fixedDeltaTime);
        
    }
}
    