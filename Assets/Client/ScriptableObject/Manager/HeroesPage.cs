using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesPage : BasePage
{
    public override void OnOpened(object parameters)
    {
        Debug.Log("Heroes page opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Heroes page closed");
    }
}