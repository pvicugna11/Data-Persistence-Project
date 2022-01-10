using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBase : MonoBehaviour
{
    public Text BestScoreText;

    protected virtual void Start()
    {
        DisplayBestScore();
    }

    protected virtual void DisplayBestScore()
    {
        BestScoreText.text = TextTemplate(BestScoreManager.Instance.PlayerNames[0], BestScoreManager.Instance.HighScores[0]);
    }

    protected string TextTemplate(string playerName, int highScore)
    {
        return $"Best Score : {playerName} : {highScore}";
    }

    public void StartStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartMain()
    {
        SceneManager.LoadScene(1);
    }

    public void StartHighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void StartSettings()
    {
        SceneManager.LoadScene(3);
    }
}
