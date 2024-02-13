using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int previousRandomIndex = -1;
    int scoreSinceLastColorChange = 0;
    int score;
    public TMP_Text scoreText;

    public GameObject GameOverPannel;
    public TMP_Text currentText;
    public TMP_Text highScoreText;
    public Button restartButton;

    public Camera mainCam;
    public RawImage backgroundImage;
    private int randomIndex;
    public Color[] colorToChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        randomIndex = Random.Range(0, colorToChange.Length);
        ChangeColor();
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        GameOverPannel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

   
    public void AddScore ()
    {
        score++;
        scoreText.text = score.ToString();
        randomIndex = Random.Range(0, colorToChange.Length);
        ApplyColor();
    }

    public void GameOver () 
    {
        if(score > PlayerPrefs.GetInt("HighScore")) 
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score", score);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        GameOverPannel.SetActive(true);
    }
    public void RestartLevel () 
    {
        SceneManager.LoadScene("GameScene");
    }

    void ApplyColor() 
    {
        scoreSinceLastColorChange++;

        // Rastgele bir renk seçilene kadar farklý bir renk seçene kadar tekrar tekrar deneyin
        do
        {
            randomIndex = Random.Range(0, colorToChange.Length);
        } 
        while (randomIndex == previousRandomIndex);

        previousRandomIndex = randomIndex;

        // Seçilen yeni indeksi önceki indeks olarak kaydet
        if (scoreSinceLastColorChange == 2) 
        {
            scoreSinceLastColorChange = 0;
            ChangeColor();
        }
        
    }

    public void ChangeColor () 
    {
        mainCam.backgroundColor = colorToChange[randomIndex];
        backgroundImage.color = colorToChange[randomIndex];
    }
}
