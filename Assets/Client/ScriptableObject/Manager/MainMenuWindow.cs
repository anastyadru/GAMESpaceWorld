using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("MainMenu window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("MainMenu window closed");
    }
}