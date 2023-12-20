using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 2f; // Скорость перемещения
    public float moveDistanceX = 3f; // Максимальное расстояние по оси X
    public float moveDistanceY = 2f; // Максимальное расстояние по оси Y
    public float shootInterval = 2f; // Интервал между выстрелами
    
    private bool isMovingRight = true; // Флаг направления движения (вправо или влево)
    private float moveTimer = 0f; // Таймер для перемещения
    private float shootTimer = 0f; // Таймер для стрельбы
    
    private void Update()
    {
        // Перемещение врага
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveSpeed)
        {
            MoveEnemy();
            moveTimer = 0f;
        }

        // Стрельба врага
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void MoveEnemy()
    {
        // Изменение позиции по оси X в заданных пределах
        float moveAmount = Random.Range(0f, moveDistanceX);
        float newX = transform.position.x + (isMovingRight ? moveAmount : -moveAmount);
        newX = Mathf.Clamp(newX, -moveDistanceX, moveDistanceX);

        // Изменение позиции по оси Y в заданных пределах
        float newY = Random.Range(-moveDistanceY, moveDistanceY);

        // Установка новой позиции
        transform.position = new Vector3(newX, newY, transform.position.z);

        // Изменение направления движения
        isMovingRight = !isMovingRight;
    }

    private void Shoot()
    {
        // Создание снаряда на позиции врага
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}