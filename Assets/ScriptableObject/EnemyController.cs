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
        if (other.CompareTag("lazerShot")) // Проверяем тег объекта
        {
            Destroy(gameObject); // Уничтожаем врага
            Destroy(other.gameObject); // Уничтожаем то, с чем стоклнулись
            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // Проверяем, остались ли еще противники в текущей волне
            {
                currentWave++; // Увеличиваем номер текущей волны
                
                if (currentWave == waveSizes.Length) // Если все волны пройдены, завершаем игру
                {
                    Debug.Log("Game Over"); // Здесь можно добавить код для завершения игры
                    return;
                }
                
                GenerateWave(waveSizes[currentWave], transform.position); // Генерируем новую волну противников
            }
        }
    }
    
    private void GenerateWave(int enemyCount, Vector3 startPosition)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, startPosition, transform.rotation); // Создаем нового противника
            float randomX = Random.Range(-100f, 100f); // Устанавливаем случайную позицию для противника
            enemy.transform.position += new Vector3(randomX, 0, 0);
        }
    }
}