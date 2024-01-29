using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed = 100; // Скорость пули

    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Вызываем метод возвращения объекта в пул
            objectPool.Release(gameObject);
        }
    }
}