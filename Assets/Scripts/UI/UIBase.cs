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

    public void DisplayBestScore()
    {
        BestScoreText.text = $"Best Score : {BestScoreManager.Instance.PlayerName} : {BestScoreManager.Instance.HighScore}";
    }
}
