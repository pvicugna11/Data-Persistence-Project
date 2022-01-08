using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIStartMenu : UIBase
{
    public void InputPlayerName(TextMeshProUGUI playerNametext)
    {
        MainManager.PlayerName = playerNametext.text;
    }

    public void StartMain()
    {
        SceneManager.LoadScene(1);
    }

    public void StartHighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
