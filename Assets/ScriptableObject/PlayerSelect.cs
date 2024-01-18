using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters;
    private int index;

	public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;

    private void Start()
    {
        index = PlayerPrefs.GetInt("SelectPlayer");
        characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        if (characters[index])
        {
            characters[index].SetActive(true);
        }
    }

    public void SelectLeft()
    {
        characters[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characters.Length - 1;
        }

        characters[index].SetActive(true);

		// Проверяем, какой корабль выбран и устанавливаем соответствующий тип выстрела
        if (index == 0)
        {
            BulletController.bulletPrefab = redBulletPrefab;
        }
        else if (index == 1)
        {
            BulletController.bulletPrefab = blueBulletPrefab;
        }
    }

    public void SelectRight()
    {
        characters[index].SetActive(false);
        index++;
        if (index == characters.Length)
        {
            index = 0;
        }

        characters[index].SetActive(true);

		if (index == 0)
        {
            BulletController.bulletPrefab = redBulletPrefab;
        }
        else if (index == 1)
        {
            BulletController.bulletPrefab = blueBulletPrefab;
        }
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt("SelectPlayer", index);
        SceneManager.LoadScene("Game");
    }
}