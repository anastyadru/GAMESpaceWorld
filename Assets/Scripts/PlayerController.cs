using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 40f; // Скорость перемещения игрока

    void Update()
    {
        // Получаем текущие координаты мыши по горизонтали
        float mouseX = Input.GetAxis("Mouse X");

        // Вычисляем новую позицию игрока
        Vector3 newPosition = transform.position + new Vector3(mouseX * speed * Time.deltaTime, 0, 0);

        // Ограничиваем движение игрока по горизонтали
        newPosition.x = Mathf.Clamp(newPosition.x, -100f, 100f);

        // Применяем новую позицию игрока
        transform.position = newPosition;
    }
}