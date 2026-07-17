using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public RBMouseInputs mouseMovement;
    public KeyboardMovement keyboardMovement;
    public float stunDuration;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CapsuleEnemy")
        {
         StartCoroutine(Stunned());   
        }
        
    }

    IEnumerator Stunned()
    {   
        if(mouseMovement != null && mouseMovement.enabled == true)
        {
        mouseMovement.enabled = false;
        
        animator.SetBool ("IsStunned", true);

        yield return new WaitForSeconds(stunDuration);

        mouseMovement.enabled = true;
        
        animator.SetBool("IsStunned", false);
        }
        if(keyboardMovement != null && keyboardMovement.enabled == true)
        {
        keyboardMovement.enabled = false;
        
        animator.SetBool ("IsStunned", true);

        yield return new WaitForSeconds(stunDuration);

        keyboardMovement.enabled = true;
        
        animator.SetBool("IsStunned", false);
        }
    }



}
