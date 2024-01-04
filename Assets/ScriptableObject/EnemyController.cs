using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab; // Объявляем переменную для префаба противника
    private int currentWave = 0; // Текущая волна
    private int[] waveSizes = { 3, 5, 4, 6, 8, 12, 8 }; // Количество противников в каждой волне

    void Start()
    {
        GenerateWave(waveSizes[currentWave], transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot") && other.gameObject == gameObject) // Проверяем тег объекта
        {
            Destroy(gameObject); // Уничтожаем врага
            Destroy(other.gameObject); // Уничтожаем то, с чем стоклнулись
            
            // Проверяем, остались ли еще противники в текущей волне
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                currentWave++; // Увеличиваем номер текущей волны

                // Если все волны пройдены, завершаем игру
                if (currentWave == waveSizes.Length)
                {
                    Debug.Log("Game Over");
                    // Здесь можно добавить код для завершения игры
                    return;
                }

                // Генерируем новую волну противников
                GenerateWave(waveSizes[currentWave], transform.position);
            }
        }
    }
    
    private void GenerateWave(int enemyCount, Vector3 startPosition)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Создаем нового противника
            GameObject enemy = Instantiate(enemyPrefab, startPosition, transform.rotation);
            
            // Устанавливаем случайную позицию для противника
            float randomX = Random.Range(-100f, 100f);
            enemy.transform.position += new Vector3(randomX, 0, 0);
        }
    }
}