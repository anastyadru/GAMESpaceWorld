using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    public GameObject bulletPrefab; // префаб снаряда
    public float fireRate = 0.2f; // частота выстрелов
    private float nextFireTime; // время следующего выстрела

    void Update()
    {
        if (Input.GetMouseButton(0)) // Проверяем, зажата ли левая кнопка мыши
        {
            if (Time.time > nextFireTime) // Проверяем, прошло ли достаточно времени с момента последнего выстрела
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation); // вперед
                Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, -15, 0) * transform.rotation); // -15 градусов
                Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 15, 0) * transform.rotation); // 15 градусов
                
                nextFireTime = Time.time + fireRate; // Устанавливаем время следующего выстрела
            }
        }
    }
}