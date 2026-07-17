using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string LevelToLoad;
    // Update is called once per frame
    public void Openscene()
    {   
        SceneManager.LoadScene(LevelToLoad);
    }
}
