using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 170f; // Скорость перемещения игрока
    public GameObject lazerShot;
    public Transform lazerGun;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // текущие координаты мыши по горизонтали
        
        Vector3 newPosition = transform.position + new Vector3(mouseX * speed * Time.deltaTime, 0, 0); // Вычисляем новую позицию игрока
        
        newPosition.x = Mathf.Clamp(newPosition.x, -220f, 180f); // Ограничиваем движение игрока по горизонтали
        
        transform.position = newPosition; // Применяем новую позицию игрока
        
        
    }
}