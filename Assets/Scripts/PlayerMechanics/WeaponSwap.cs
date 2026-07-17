using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public GameObject swordHolder;
    public GameObject bulletPointer;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SwitchWeapons();
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            SwapControls();
        }
    }

    void SwitchWeapons()
    {
       //switch weapons
      swordHolder.SetActive(!swordHolder.activeInHierarchy); 
      bulletPointer.SetActive(!bulletPointer.activeInHierarchy);
    }

    void SwapControls()
    {
    this.gameObject.GetComponent<KeyboardMovement>().enabled = !(this.gameObject.GetComponent<KeyboardMovement>().enabled);
    this.gameObject.GetComponent<RBMouseInputs>().enabled = !(this.gameObject.GetComponent<RBMouseInputs>().enabled);
     if (GameObject.FindGameObjectWithTag("TargetPosition") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("TargetPosition"));

            }
    }
}
