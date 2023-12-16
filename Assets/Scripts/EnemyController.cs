using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 3f; // Скорость перемещения врага
    private float heightChangeSpeed = 2f; // Скорость изменения высоты врага
    private float shootingInterval = 2f; // Интервал между выстрелами врага
    private float shootingTimer = 0f; // Таймер для отслеживания интервала выстрелов
    public GameObject bulletPrefab; // Префаб пули врага

    void Update()
    {
        // Вычисляем новую позицию врага
        Vector3 newPosition = transform.position + new Vector3(speed * Time.deltaTime, Mathf.Sin(Time.time * heightChangeSpeed), 0);

        // Применяем новую позицию врага
        transform.position = newPosition;

        // Проверяем, прошло ли достаточно времени для выстрела
        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingInterval)
        {
            // Сбрасываем таймер выстрелов
            shootingTimer = 0f;

            // Создаем пулю врага
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Задаем направление движения пули
            bullet.GetComponent<Rigidbody>().velocity = Vector3.left * 10f;
        }
    }
}