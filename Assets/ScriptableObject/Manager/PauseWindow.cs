using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("Pause window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Pause window closed");
    }
}