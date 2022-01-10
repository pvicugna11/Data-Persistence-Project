using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
