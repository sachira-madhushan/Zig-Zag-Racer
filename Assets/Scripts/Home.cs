using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public TextMeshProUGUI score, coins;
    private void Start()
    {
        score.text = PlayerPrefs.GetInt("HighScore", 000).ToString();
        coins.text = PlayerPrefs.GetInt("Coins", 000).ToString();

        print(PlayerPrefs.GetInt("HighScore", 000));
        print(PlayerPrefs.GetInt("Coins", 000));
    }
    public void Play()
    {
        SceneManager.LoadScene("Select");
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
