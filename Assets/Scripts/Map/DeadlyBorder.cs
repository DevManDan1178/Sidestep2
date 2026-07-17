using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyBorder : MonoBehaviour
{
    public int damage;
    public GameObject player;

    public GameObject collisionEffect;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {   
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
                
            }
    
        Instantiate(collisionEffect, transform.position, transform.rotation);
    }

    
}
