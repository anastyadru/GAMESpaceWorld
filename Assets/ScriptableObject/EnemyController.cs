using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 170f; // Скорость перемещения врага
    private Vector3 randomDirection; // Случайное направление движения

    private void Start()
    {
        // Задаем случайное начальное направление движения
        randomDirection = new Vector3(Random.Range(-150f, 150f), Random.Range(-150f, 150f), 0f).normalized;
    }

    private void Update()
    {
        // Перемещаем врага в заданном направлении
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        // Если враг достиг границы экрана, меняем направление на случайное
        if (transform.position.x < -150f || transform.position.x > 150f ||
            transform.position.y < -150f || transform.position.y > 150f)
        {
            randomDirection = new Vector3(Random.Range(-150f, 150f), Random.Range(-150f, 150f), 0f).normalized;
        }
    }
}