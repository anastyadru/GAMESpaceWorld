using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLeftWindow : MonoBehaviour
{
    public override void OnOpened()
    {
        Debug.Log("ChoiceLeft window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("ChoiceLeft window closed");
    }
}