using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //Singleton

    public int score;
    public int hightScore;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        if (PlayerPrefs.HasKey("HightScore"))
            hightScore = PlayerPrefs.GetInt("HightScore");
        else
            hightScore = 0;
    }

    public void AddScore(int scoreToAdd)
    {
        Debug.Log("AddScore");
        score += scoreToAdd;

        UIManager.Instance.UpdateScore(score);

        if (score > hightScore)
        {
            hightScore = score;
            PlayerPrefs.GetInt("HightScore", hightScore);
        }
    }
}