using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCollision : MonoBehaviour
{
    public int heal;
    public GameObject player;

    public GameObject collisionEffect;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy collision");
        
        if (collision.gameObject.tag == "Player")
            {   
            Player player = collision.gameObject.GetComponent<Player>();
            player.HealDamage(heal);
            Destroy(gameObject);
            Instantiate(collisionEffect, transform.position, transform.rotation);    
            }
    }

    
}
