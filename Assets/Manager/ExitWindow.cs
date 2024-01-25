using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWindow : MonoBehaviour
{
    public override void OnOpened()
    {
        Debug.Log("Exit window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Exit window closed");
    }
}