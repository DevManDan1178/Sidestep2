using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
  
    private float timer;
    public float timeUntilDeletion = 3f;



    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(Selfdestruct());
    }

    IEnumerator Selfdestruct()
    {

        timer += Time.deltaTime;

        if (timer > timeUntilDeletion)
        {
        Destroy(gameObject); 
         
        }

        else
        {
        yield return new WaitForSeconds(0.5f);
        }
        
    }
}
