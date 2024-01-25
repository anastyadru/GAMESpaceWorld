using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmWindow : MonoBehaviour
{
    public override void OnOpened()
    {
        Debug.Log("Confirm window opened");
    }

    public override void OnClosed()
    {
        Debug.Log("Confirm window closed");
    }
}