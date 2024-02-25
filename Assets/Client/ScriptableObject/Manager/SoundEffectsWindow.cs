using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsWindow : BaseWindow
{
    public override void OnOpened()
    {
        Debug.Log("SoundEffects window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("SoundEffects window closed");
    }
}