using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed; // Скорость пули

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }
}