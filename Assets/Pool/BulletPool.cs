using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public int poolSize = 10; // Размер пула пуль
    private List<GameObject> bulletPool; // Список объектов пула

    public void PrePool()
    {
        bulletPool = new List<GameObject>();

        // Создание и добавление объектов пула в список
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject Get()
    {
        // Поиск неактивной пули в пуле
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        // Если все пули заняты, создаем новую
        GameObject newBullet = Instantiate(bulletPrefab);
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public void Release(GameObject bullet)
    {
        // Деактивируем пулю и возвращаем ее в пул
        bullet.SetActive(false);
    }
}