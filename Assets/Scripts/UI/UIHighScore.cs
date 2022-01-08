using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHighScore : UIBase
{
    public void BackToStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
