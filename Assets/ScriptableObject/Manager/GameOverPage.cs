using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPage : BasePage
{
    public override void OnOpened(object parameters)
    {
        Debug.Log("GameOver page opened");
    }

    public override void OnClosed()
    {
        Debug.Log("GameOver page closed");
    }
}