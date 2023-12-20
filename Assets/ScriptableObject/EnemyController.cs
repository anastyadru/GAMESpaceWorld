using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 2f; // Скорость перемещения
    public float moveDistanceX = 30f; // Максимальное расстояние по оси X
    public float moveDistanceY = 5f; // Максимальное расстояние по оси Y
    
    public float shootInterval = 2f; // Интервал между выстрелами
    private bool isMovingRight = true; // Флаг направления движения (вправо или влево)
    private float moveTimer = 0f; // Таймер для перемещения
    private float shootTimer = 0f; // Таймер для стрельбы
    
}