using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public float shootingInterval = 0.1f; // Интервал между выстрелами

    private float shootingTimer = 0f; // Таймер для отслеживания интервала выстрелов

    void Update()
    {
        // Проверяем, зажата ли левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            // Обновляем таймер выстрелов
            shootingTimer += Time.deltaTime;

            // Если прошло достаточно времени для выстрела
            if (shootingTimer >= shootingInterval)
            {
                // Сбрасываем таймер выстрелов
                shootingTimer = 0f;

                // Создаем пулю
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}