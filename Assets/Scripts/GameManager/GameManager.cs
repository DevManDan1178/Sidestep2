using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    bool gameHasEnded = false;

    public LevelBar levelBar;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public float levelDuration = 150f;

    public float levelPauseTimer = 128f;

    public float levelPauseDuration = 3f;

    private float PauseTime;

    public bool levelPause = false;
    private bool levelCompleted;
    private bool mouseControl;
    private bool keyboardControl;
    public float nextLevelPauseTimer = 1000f;

    public bool endlessLevel = false;
    private float destroyDelay = 0.1f;
    private GameObject player;
    void Start()
    {   //LOAD CONTROLS
        player = GameObject.Find("Player");
        LoadControls();
        Debug.Log("Started");
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
        (player.GetComponent<KeyboardMovement>().enabled) = keyboardControl;
        (player.GetComponent<RBMouseInputs>().enabled) = mouseControl;  
    
        //PAUSE  TIME
        PauseTime = levelPauseDuration;
        //convert to int
        levelBar.SetMaxTime(Mathf.RoundToInt(levelDuration));
        FindAnyObjectByType<AudioManager>().Play("LevelAudio");

    }

    void Update()
    {
        if(endlessLevel == false)
        {
            StartCoroutine(Leveltimer());      
        }
        
    }
    IEnumerator Leveltimer()
    {  
       if (levelCompleted != true)
       {
       levelDuration -= Time.deltaTime;
       }

       

   
       levelBar.SetTime(Mathf.RoundToInt(levelDuration));
       


        if(levelDuration <=2)
        {
             DestroyObjects("Spawner");
            yield return new WaitForSeconds(2);
            Completelevel();
        
        }

        if(levelPause == true)
        { 
            
            
            if(levelPauseTimer > 2)
            {
                levelPauseTimer -= Time.deltaTime;
            }
            if(levelPauseTimer <= 2)
            {
                GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
                foreach(GameObject spawner in spawners)
                {
                spawner.SetActive(false);

                yield return new WaitForSeconds(levelPauseDuration);

                spawner.SetActive(true);
                }
                levelPauseTimer = nextLevelPauseTimer;
            }

            
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
    
    }

    public void Completelevel()
    {   
        levelCompleted = true;
        completeLevelUI.SetActive(true);
        DestroyObjects("Enemy");
        DestroyObjects("Enemyblock");
        DestroyObjects("Obstacle");
        DestroyObjects("EnemyShooter");
        DestroyObjects("EnemyStraightShooter");
        DestroyObjects("CapsuleEnemy");
    } 

    public void DestroyObjects(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (tag);
        foreach(GameObject gameobject in gameObjects)
        {
            GameObject.Destroy(gameobject, destroyDelay);
        }
    }



    public void EndGame()
    {
        if (gameHasEnded == false)
        {   
            
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
            
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void LoadControls()
    {
        ControlPrefData data = SaveSystem.LoadControls();
        mouseControl = data.mouseControls;
        keyboardControl = data.keyboardControls;
    }    
}
