using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : UIBase
{
    public MainManager Manager;

    protected override void Start()
    {
        base.Start();
        Manager.onBestScoreUpdated += DisplayBestScore;
    }
}
