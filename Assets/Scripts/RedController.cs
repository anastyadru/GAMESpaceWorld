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
        if (Input.GetMouseButton(0)) // Проверяем, зажата ли левая кнопка мыши
        {
            shootingTimer += Time.deltaTime; // Обновляем таймер выстрелов
            
            if (shootingTimer >= shootingInterval) // Если прошло достаточно времени для выстрела
            {
                shootingTimer = 0f; // Сбрасываем таймер выстрелов
                
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Создаем пулю
            }
        }
    }
}