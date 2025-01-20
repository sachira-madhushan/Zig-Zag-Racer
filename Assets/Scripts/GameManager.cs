using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AdManager admanager = new AdManager();
    public static GameManager instance;

    public Text scoreText;
    public Text highScoreText;

    public bool gameStarted;

    public GameObject platformSpawner;
    public GameObject menuPanel;
    public GameObject GamePlayUI;

    int highScore;
    public int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "Best Score : " + highScore;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Game");
            }

        }
    }

    void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);

        menuPanel.SetActive(false);
        GamePlayUI.SetActive(true);
        StartCoroutine("UpdateScore");

    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        print("GameOver");
        StopCoroutine("UpdateScore");
        SaveHighScore();
        admanager.LoadNonRewardedAd();
        admanager.ShowNonRewardedAd();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }
    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }

    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
                
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
