using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public Animator animator;
    public PointToMouse movement;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public TrailRenderer trailRenderer;

    public int attackDamage = 2;
    public float attackCooldown = .5f;
    private float cooldownTimer = 0;
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }
        movement.enabled = true;
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
            
        }
    }

    //attack
    public void Attack()
    {   
        if (cooldownTimer > 0)
        {
            return;
        }
        movement.enabled = false;
        animator.SetTrigger("SwordSwipe");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
        cooldownTimer = attackCooldown;
    }
    //radius
     void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void MovementRestore()
    {
        movement.enabled = true;
    }
}
