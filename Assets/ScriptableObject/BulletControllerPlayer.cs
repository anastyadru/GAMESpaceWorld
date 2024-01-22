using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerPlayer : MonoBehaviour
{
    public float speed = 100; // Скорость пули

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }
}