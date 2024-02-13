using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }
    int score;
    public TMP_Text scoreText;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore ()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver () 
    {
        Debug.Log("Game Over!");
    }
}
