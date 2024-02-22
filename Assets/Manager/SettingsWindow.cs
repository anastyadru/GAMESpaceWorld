using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("Settings window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Settings window closed");
    }
}