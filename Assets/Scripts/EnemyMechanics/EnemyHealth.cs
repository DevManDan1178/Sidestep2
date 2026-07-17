using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    public GameObject deathEffect;
    public int maxHealth = 1;
    int currentHealth;

    public int lifestealValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play damage animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die() 
    {
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            
            FindAnyObjectByType<Player>().HealDamage(lifestealValue);
        }
    }
}
