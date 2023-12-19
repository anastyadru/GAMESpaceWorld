using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : MonoBehaviour
{
    public GameObject bulletPrefab; // префаб снаряда
    public float fireRate = 0.1f; // частота выстрелов
    private float nextFireTime; // время следующего выстрела

    void Update()
    {
        if (Input.GetMouseButton(0)) // Проверяем, зажата ли левая кнопка мыши
        {
            if (Time.time > nextFireTime) // Проверяем, прошло ли достаточно времени с момента последнего выстрела
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation); // Создаем новый снаряд в позиции корабля
                nextFireTime = Time.time + fireRate; // Устанавливаем время следующего выстрела
            }
        }
    }
}