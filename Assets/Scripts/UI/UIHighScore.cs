using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHighScore : UIBase
{
    public Text TextPrefab;
    public Transform Content;

    public void BackToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    protected override void DisplayBestScore()
    {
        base.DisplayBestScore();
        for (int i = 1; i < BestScoreManager.Instance.MaxSaveNum; i++)
        {
            var text = Instantiate(TextPrefab);
            text.text = TextTemplate(BestScoreManager.Instance.PlayerNames[i], BestScoreManager.Instance.HighScores[i]);
            text.transform.SetParent(Content);
        }
    }
}
