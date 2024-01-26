using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour, IPoolable
{
    public float speed = 100; // Скорость пули
    private BulletPool bulletPool;
    private GameObject bullet;

    void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();
        bullet = bulletPool.GetWithTag("lazerGun1");
    }

    void Update()
    {
        bullet.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void OnRelease()
    {
        bulletPool.Release(bullet);
    }
}