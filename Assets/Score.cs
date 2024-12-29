using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text t;
    public int CurrentScore;
    public int HighScore;

    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        if(CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        t.text = "Happy Ducks: " + CurrentScore + " \n" + "High Score: " + HighScore;
    }
}
