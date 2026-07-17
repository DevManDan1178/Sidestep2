using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchControls : MonoBehaviour
{
    public static bool mouseControl;
    public static bool keyboardControl;
    public Text controlTypeText;
    private int mouseORkeyboard;
    public GameObject player;

    void OnEnable()
    {   //previous control type

        LoadControls();
        if (PlayerPrefs.GetString("mouseORkeyboard") == "Mouse")
        {
            mouseControl = true;
            keyboardControl = false;
        }
        if (PlayerPrefs.GetString("mouseORkeyboard") == "Keyboard")
        {
            mouseControl = false;
            keyboardControl = true;
        }
        else
        {
            mouseControl = true;
            keyboardControl = false;
            PlayerPrefs.SetString("mouseORkeyboard", "Mouse");
        }

        (player.GetComponent<KeyboardMovement>().enabled) = keyboardControl;
        (player.GetComponent<RBMouseInputs>().enabled) = mouseControl;  
        //display on button
        controlTypeText.text = PlayerPrefs.GetString("mouseORkeyboard").ToString();
        
        
    }

    // Update is called once per frame
    public void ChangeControls()
    { 
        if (GameObject.FindGameObjectWithTag("TargetPosition") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("TargetPosition"));
                player.GetComponent<RBMouseInputs>().targetPosition = player.transform.position;
            }
        //if _control is false, activate _control and disactivate other
        
        mouseControl = !mouseControl;
        keyboardControl = !keyboardControl;
        if (player == null)
        {
            player = FindAnyObjectByType<Player>().gameObject;
        }
        player.GetComponent<KeyboardMovement>().enabled = keyboardControl;
        RBMouseInputs mouseInputs = player.GetComponent<RBMouseInputs>();
        mouseInputs.enabled = mouseControl;
        mouseInputs.ResetTarget();
        //mouseorkeyboard    
        if (mouseControl == true)
        {
        PlayerPrefs.SetString("mouseORkeyboard", "Mouse");
        }
        if (keyboardControl == true)
        {
        PlayerPrefs.SetString("mouseORkeyboard", "Keyboard");
        }
        SaveSystem.SaveControls(mouseControl, keyboardControl);

        controlTypeText.text = keyboardControl ? "Keyboard" : "Mouse";    
    }
    public void LoadControls()
    {
        ControlPrefData data = SaveSystem.LoadControls();
        if(data.mouseControls != data.keyboardControls)
        mouseControl = data.mouseControls;
        keyboardControl = data.keyboardControls;
    }
}
