using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 170f; // Скорость перемещения игрока

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // текущие координаты мыши по горизонтали
        
        Vector3 newPosition = transform.position + new Vector3(mouseX * speed * Time.deltaTime, 0, 0); // Вычисляем новую позицию игрока
        
        newPosition.x = Mathf.Clamp(newPosition.x, -200f, 200f); // Ограничиваем движение игрока по горизонтали
        
        transform.position = newPosition; // Применяем новую позицию игрока
    }
}