using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWinnigsPage : BasePage
{
    public override void OnOpened(object parameters)
    {
        Debug.Log("GameOverWinnigs page opened");
    }

    public override void OnClosed()
    {
        Debug.Log("GameOverWinnigs page closed");
    }
}