using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public GameObject scoreBoard;
    
    [Header("Medals")] 
    public Sprite goldMedal;
    public Sprite silverMedal;
    public Sprite bronzeMedal;
    
    [Header("Textboxes")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    private void Start()
    {
        scoreBoard.SetActive(false);
    }

    public void ShowScore(int score)
    {
        scoreText.text = "score: " + score.ToString();
        scoreBoard.SetActive(true);
        //TODO: medals
        //TODO: get best score
        if (PlayerPrefs.HasKey("BestScore"))
        {
            var best = PlayerPrefs.GetInt("BestScore");

            if (best > score)
            {
                bestText.text = "best: " + best.ToString();
            }
            else
            {
                bestText.text = "best: " + score.ToString();
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            bestText.text = score.ToString();
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }
}
