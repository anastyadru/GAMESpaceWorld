using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerPlayer : MonoBehaviour, IPoolable
{
    public float speed = 100; // Скорость пули
    
    private ObjectPool bulletPool;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
    }

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.health -= 5;

            if (enemy.health <= 0)
            {
                enemy.OnRelease();
                bulletPool.Release(this);
            }
        }
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}