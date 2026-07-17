using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
[System.Serializable]
public class ControlPrefData
{
  
    
        public bool mouseControls;
        public bool keyboardControls;

        public ControlPrefData (bool mouseControlled, bool keyboardControlled)
        {
            mouseControls = mouseControlled;
            keyboardControls = keyboardControlled;
        }
    
}