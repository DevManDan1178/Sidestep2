using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{   
    public void toggleGameObject(GameObject weapon)
{
    
   
    if(weapon.activeSelf == true)
    {
        weapon.SetActive(false);
    }
    else
    {
        weapon.SetActive(true);
    }
}
}
