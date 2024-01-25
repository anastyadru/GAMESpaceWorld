using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("Heroes window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Heroes window closed");
    }
}