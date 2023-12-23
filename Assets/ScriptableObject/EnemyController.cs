using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 250f; // Скорость перемещения
    private float smoothness = 3f; // Плавность движения

    private Vector3 targetPosition; // Целевая позиция
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime; // время следующего выстрела

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

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime); // Плавно перемещаем игрока к целевой позиции
    }

    void GenerateNewTargetPosition()
    {
        float randomX = Random.Range(-100f, 100f); // Генерируем случайное значение по оси X
        targetPosition = transform.position + new Vector3(randomX, 0, 0); // Изначально целевая позиция равна текущей позиции + случайное значение по оси X
        
        targetPosition.x = Mathf.Clamp(targetPosition.x, -500f, -100f); // Ограничиваем движение игрока по горизонтали
    }
    
    // Вызывается при столкновении с другим объектом (переменная other)
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // уничтожаем врага
        Destroy(other.gameObject); // уничтожаем то, с чем стоклнулись
    }
}