using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;
    public Animator animator;
    public HealthBar healthBar;

    public GameObject deathEffect;

    private int extraHealth;
  
    //take damage
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        StartCoroutine(TakingDamage());
        FindAnyObjectByType<AudioManager>()?.Play("DamageAudio");
        if (currentHealth <= 0)
        {
            Die();
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    IEnumerator TakingDamage()
    { 
        animator.SetBool("TakingDamage", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("TakingDamage", false);


    }

    //heal damage
    public void HealDamage (int heal)
    {
        
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            extraHealth = currentHealth - maxHealth;
            currentHealth -= extraHealth;
        }

        healthBar.SetHealth(currentHealth);
        StartCoroutine(HealingDamage());
        FindAnyObjectByType<AudioManager>().Play("HealAudio");
    }

    IEnumerator HealingDamage()
    { 
        animator.SetBool("HealingDamage", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("HealingDamage", false);

    }


    //die 
    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        FindAnyObjectByType<GameManager>().EndGame();
        FindAnyObjectByType<AudioManager>().Play("DeathAudio");
    }
}
