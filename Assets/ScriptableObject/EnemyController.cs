using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Mathf;

public class EnemyController : MonoBehaviour
{
    private float speed = 200f; // Скорость перемещения игрока
    private float smoothness = 5f; // Плавность движения

    private Vector3 targetPosition; // Целевая позиция игрока

    void Start()
    {
        GenerateNewTargetPosition();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // Если враг близок к целевой позиции
        {
            GenerateNewTargetPosition(); // Генерируем новую целевую позицию
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime); // Плавно перемещаем игрока к целевой позиции
    }

    void GenerateNewTargetPosition()
    {
        float randomX = Random.Range(-5f, 5f); // Генерируем случайное значение по оси X
        targetPosition = transform.position + new Vector3(randomX, 0, 0); // Изначально целевая позиция равна текущей позиции + случайное значение по оси X
    }
}