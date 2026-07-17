using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowPlayGame : MonoBehaviour
{

    public GameObject HowToPlayUI;
    // Start is called before the first frame update
    public void HowToPlay()
    {
        HowToPlayUI.SetActive(true);
    }
}
