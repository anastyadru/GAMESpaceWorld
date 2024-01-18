using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed; // Скорость пули

    void Start()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}