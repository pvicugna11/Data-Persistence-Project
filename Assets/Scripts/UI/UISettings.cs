using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : UIBase
{
    protected override void Start() {}

    public void ChangeFullScreen(Toggle toggle)
    {
        Screen.fullScreen = toggle.isOn;
    }
}
