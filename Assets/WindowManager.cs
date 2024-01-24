using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private static WindowManager instance;
    private Stack<Window> windowStack = new Stack<Window>();
    
    public static WindowManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<WindowManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("WindowManager");
                    instance = container.AddComponent<WindowManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        windowStack = new Stack<BaseWindow>();
    }

    public void Open(WindowID windowID)
    {
        BaseWindow window = GetWindow(windowID);
        if (window != null)
        {
            window.gameObject.SetActive(true);
            window.OnOpened();
            windowStack.Push(window);
        }
    }

    public void CloseLast()
    {
        if (windowStack.Count > 0)
        {
            BaseWindow window = windowStack.Pop();
            window.OnClosed();
            window.gameObject.SetActive(false);
        }
    }

    private BaseWindow GetWindow(WindowID windowID)
    {
        switch (windowID)
        {
            case WindowID.Heroes:
                return FindObjectOfType<HeroesWindow>();
            case WindowID.Settings:
                return FindObjectOfType<SettingsWindow>();
            case WindowID.Exit:
                return FindObjectOfType<ExitWindow>();
            case WindowID.Settings:
                return FindObjectOfType<SettingsWindow>();
            default:
                return null;
        }
    }
}