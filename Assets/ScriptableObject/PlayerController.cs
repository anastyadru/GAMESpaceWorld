using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 250f; // Скорость перемещения игрока
    public GameObject lazerShot;
    public Transform lazerGun;
    private float nextShotTime; // Время следующего выстрела

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // Текущие координаты мыши по горизонтали
        
        Vector3 newPosition = transform.position + new Vector3(mouseX * speed * Time.deltaTime, 0, 0); // Вычисляем новую позицию игрока
        
        newPosition.x = Mathf.Clamp(newPosition.x, -300f, 210f); // Ограничиваем движение игрока по горизонтали
        
        transform.position = newPosition; // Применяем новую позицию игрока

        if (Input.GetButton("Fire2") && Time.time > nextShotTime)
        {
            int index = PlayerPrefs.GetInt("SelectPlayer");

            if (index == 0)
            {
                Instantiate(lazerShot, lazerGun.position, Quaternion.identity);
                nextShotTime = Time.time + 0.1f;
            }
            else if (index == 1)
            {
                Instantiate(lazerShot, lazerGun.position, Quaternion.identity);
                Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0, -15, 0));
                Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0, 15, 0));
                nextShotTime = Time.time + 0.2f;
            }
        }
    }
}