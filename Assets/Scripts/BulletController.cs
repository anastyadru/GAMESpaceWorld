using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 40f; // Скорость пули

    void Update()
    {
        // Двигаем пулю вперед с постоянной скоростью
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}