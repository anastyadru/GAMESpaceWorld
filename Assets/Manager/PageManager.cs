using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    private static PageManager instance;
    private BasePage currentPage;

    public static PageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PageManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("PageManager");
                    instance = container.AddComponent<PageManager>();
                }
            }
            return instance;
        }
    }

    public void Open(PageID pageID, object parameters = null)
    {
        if (currentPage != null)
        {
            currentPage.OnClosed();
            Destroy(currentPage.gameObject);
        }

        BasePage page = GetPage(pageID);
        if (page != null)
        {
            GameObject pageObject = Instantiate(page.gameObject);
            currentPage = pageObject.GetComponent<BasePage>();
            currentPage.OnOpened(parameters);
        }
    }

    private BasePage GetPage(PageID pageID)
    {
        switch (pageID)
        {
            case PageID.MainMenu:
                return FindObjectOfType<MainMenuPage>();
            case PageID.ChooseHero:
                return FindObjectOfType<ChooseHeroPage>();
            case PageID.Game:
                return FindObjectOfType<GamePage>();
            default:
                return null;
        }
    }
}