using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float fireRateRed = 0.1f;
    public float fireRateBlue = 0.2f;

    private GameObject bulletPrefabEnemy;
    private float nextShotTime;

    private void Start()
    {
        PlayerSelect playerSelect = FindObjectOfType<PlayerSelect>();
        int index = PlayerPrefs.GetInt("SelectPlayer");

        if (index == 0)
        {
            bulletPrefabEnemy = playerSelect.redBulletPrefab;
        }
        else if (index == 1)
        {
            bulletPrefabEnemy = playerSelect.blueBulletPrefab;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextShotTime)
        {
            if (bulletPrefabEnemy == redBulletPrefab)
            {
                Instantiate(bulletPrefabEnemy, transform.position, Quaternion.identity);
                nextShotTime = Time.time + fireRateRed;
            }
            else if (bulletPrefabEnemy == blueBulletPrefab)
            {
                Instantiate(bulletPrefabEnemy, transform.position, Quaternion.identity);
                Instantiate(bulletPrefabEnemy, transform.position, Quaternion.Euler(0, -15, 0));
                Instantiate(bulletPrefabEnemy, transform.position, Quaternion.Euler(0, 15, 0));
                nextShotTime = Time.time + fireRateBlue;
            }
        }
    }
}