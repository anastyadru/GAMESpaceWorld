using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{ 
    public float speed; // Скорость пули
    
    // public float speed = 100f; // Скорость пули

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }

    // void Update()
    // {
        // Двигаем пулю вперед с постоянной скоростью
        // transform.Translate(Vector3.up * speed * Time.deltaTime);
    // }
}