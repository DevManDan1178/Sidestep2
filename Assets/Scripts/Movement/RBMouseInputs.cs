using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMouseInputs : MonoBehaviour
{

    public float rotationspeed = 5;
    public float speed = 3f;
    [HideInInspector]
    public Vector2 targetPosition;
    public Rigidbody2D rb;
    public Vector2 movementDirection;
    public  GameObject targetPositionIndicator;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }
    
    public void ResetTarget()
    {
        targetPosition = rb.position;
        movementDirection = Vector2.zero;
    }
     
    //Called every frame
    void Update() {
        //If the player wants to stop any previous movement, reset the movement and stop checking for other inputs.
        if (Input.GetKey(KeyCode.S)) {
            //Set the target position to its own position so it will avoid moving in future calls
            ResetTarget();
            return;
        }
        //If the player did not change the target, avoid overshooting.
        if (!Input.GetMouseButtonDown(1)) {
            
            Vector2 deltaPosition = targetPosition - rb.position;
            
            //If the distance from the targeted position is very small, stop moving (arbitrary threshold of 0.0025 square magnitude chosen)
            movementDirection = deltaPosition.sqrMagnitude <= 0.0025 ? Vector2.zero : deltaPosition.normalized;
            return;
        }
        //Set the target to the position of our mouse in the world's coordinates (we can get it from the screen coordinates with our camera)
        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Set the target position to the mouse's position in the game world
        targetPosition = new Vector2(screenToWorldPoint.x, screenToWorldPoint.y);

        //Set the movement direction to be moving towards the target position. Normalize it so it remains a unit vector.
        movementDirection = (targetPosition - rb.position).normalized;
    }
           
    void FixedUpdate() 
    {
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed);
        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime);
    }   
}


