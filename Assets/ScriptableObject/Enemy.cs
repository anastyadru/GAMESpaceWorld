using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 250f; // Скорость перемещения
    private float smoothness = 3f; // Плавность движения

    private Vector3 targetPosition; // Целевая позиция
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime; // Время следующего выстрела
    
    void Start()
    {
        GenerateNewTargetPosition();
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 10f) // Если враг близок к целевой позиции
        {
            GenerateNewTargetPosition(); // Генерируем новую целевую позицию
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime); // Плавно перемещаем к целевой позиции
        
        if (Time.time > nextShotTime)
        {
            Shoot();
        }
    }

    void GenerateNewTargetPosition()
    {
        float randomX = Random.Range(-50f, 500f); // Генерируем случайное значение по оси X в пределах, где должны находиться враги
        targetPosition = new Vector3(randomX, transform.position.y, transform.position.z); // Изменяем только координату X целевой позиции, остальные координаты оставляем без изменений
    }
    
    void Shoot()
    {
        Instantiate(lazerShot1, lazerGun1.position, Quaternion.identity);
        nextShotTime = Time.time + 4f;
    }
}