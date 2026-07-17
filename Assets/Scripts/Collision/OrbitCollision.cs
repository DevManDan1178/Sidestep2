using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCollision : MonoBehaviour
{
    //start on collision
    public void OnTriggerEnter2D (Collider2D collider)
    {
        Debug.Log("Orbit Collision");
    }
    
}
