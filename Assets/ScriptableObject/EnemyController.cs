using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 170f; // Скорость перемещения врага
    private Vector3 randomDirection; // Случайное направление движения
    private float nextDirectionChangeTime; // Время следующего изменения направления

    void Start()
    {
        // Генерируем случайное направление движения
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        nextDirectionChangeTime = Time.time + Random.Range(1f, 3f); // Устанавливаем время следующего изменения направления
    }

    void Update()
    {
        // Перемещаем враг в заданном направлении
        transform.position += randomDirection * speed * Time.deltaTime;

        // Проверяем достижение границы экрана и меняем направление при необходимости
        if (transform.position.x < -150f || transform.position.x > 150f ||
            transform.position.y < -150f || transform.position.y > 150f ||
            Time.time > nextDirectionChangeTime)
        {
            // Генерируем новое случайное направление движения
            randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            nextDirectionChangeTime = Time.time + Random.Range(1f, 3f); // Устанавливаем время следующего изменения направления
        }
    }
}