using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 170f; // Скорость перемещения игрока
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
            string selectedShip = PlayerPrefs.GetString("SelectedShip"); // Получаем выбранный корабль из сохраненных данных
            
            // if (selectedShip.Contains("SpaceshipRed"))
            // {
                Instantiate(lazerShot, lazerGun.position, Quaternion.identity);
                nextShotTime = Time.time + 0.1f;
            // }
            // else if (selectedShip.Contains("SpaceshipBlue"))
            // {
                // Instantiate(lazerShot, lazerGun.position, transform.rotation);
                // Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0, -15, 0) * transform.rotation);
                // Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0, 15, 0) * transform.rotation);
                // nextShotTime = Time.time + 0.2f;
            // }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot1")) // Проверяем тег объекта
        {
            Destroy(gameObject); // Уничтожаем врага
            Destroy(other.gameObject); // Уничтожаем то, с чем стоклнулись
        }
    }
}