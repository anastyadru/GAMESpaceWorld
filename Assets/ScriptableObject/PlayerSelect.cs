using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public GameObject redShip;
    public GameObject blueShip;

    private GameObject selectedShip;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("SelectPlayer");

        if (index == 0)
        {
            selectedShip = redShip;
        }
        else if (index == 1)
        {
            selectedShip = blueShip;
        }

        Instantiate(selectedShip, transform.position, Quaternion.identity);
    }

    public void SelectLeft()
    {
        PlayerPrefs.SetInt("SelectPlayer", 0);
    }

    public void SelectRight()
    {
        PlayerPrefs.SetInt("SelectPlayer", 1);
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }
}