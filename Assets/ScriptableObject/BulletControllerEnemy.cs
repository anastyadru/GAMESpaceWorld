using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed = 100; // Скорость пули

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}