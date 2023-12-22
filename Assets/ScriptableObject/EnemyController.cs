using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxX = 10f;
    public float minX = -10f;
    public float maxY = 4f;
    public float minY = -4f;
    private int moveDirectionX = 1;
    private int moveDirectionY = 1;

    void Start()
    {
        // Запускаем корутину для случайного движения
        StartCoroutine(RandomMovement());
    }

    void Update()
    {
        // Движение влево и вправо
        transform.Translate(Vector2.right * moveSpeed * moveDirectionX * Time.deltaTime);

        // Проверка ограничений по сцене по горизонтали
        if (transform.position.x >= maxX)
        {
            moveDirectionX = -1;
        }
        else if (transform.position.x <= minX)
        {
            moveDirectionX = 1;
        }

        // Движение вверх и вниз
        transform.Translate(Vector2.up * moveSpeed * moveDirectionY * Time.deltaTime);

        // Проверка ограничений по сцене по вертикали
        if (transform.position.y >= maxY)
        {
            moveDirectionY = -1;
        }
        else if (transform.position.y <= minY)
        {
            moveDirectionY = 1;
        }
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            // Ждем случайное время перед следующим изменением направления
            yield return new WaitForSeconds(Random.Range(1f, 5f));

            // Случайно выбираем направление движения по горизонтали
            moveDirectionX = Random.Range(-1, 2);

            // Случайно выбираем направление движения по вертикали
            moveDirectionY = Random.Range(-1, 2);
        }
    }
}