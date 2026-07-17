using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Score : MonoBehaviour
{   
    public Text scoreText;
    public Text highScoreText;
    public float scoreAmount = 0;

    public float pointsPerSecond = 1f;

    private static int highScoreAmount = 0;

    void Start()
    {
        LoadHighscore();
        highScoreText.text = "High - " + PlayerPrefs.GetInt("Highscore", highScoreAmount).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)scoreAmount + "");
        scoreAmount += pointsPerSecond * Time.deltaTime;

        
        if ((int)scoreAmount > PlayerPrefs.GetInt("Highscore") && (int)scoreAmount > highScoreAmount)
        {
            highScoreAmount = (int)scoreAmount;
            PlayerPrefs.SetInt("HighScore", highScoreAmount);
            highScoreText.text = "High - " + highScoreAmount.ToString();
            HighscoreSave();
        
        }
    }
    public void HighscoreSave()
    {
       SaveSystem.SaveHighscore(highScoreAmount); 
    }
    public void LoadHighscore ()
    {
        HighScoreData data = SaveSystem.LoadHighscore();
        highScoreAmount = data.highscore;
        highScoreText.text = "High - " + data.highscore.ToString();
    }
}

     
