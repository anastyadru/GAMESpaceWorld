using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : BasePage
{
    public override void OnOpened(object parameters)
    {
        Debug.Log("Menu page opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Menu page closed");
    }
}