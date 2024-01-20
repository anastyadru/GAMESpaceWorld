using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab; // Объявляем переменную для префаба противника
    private int currentWave = 0; // Текущая волна
    private int[] waveSizes = { 3, 5, 4, 6, 8, 12, 8 }; // Количество противников в каждой волне
    private float enemyHealthMultiplier = 1.05f;
    
    private int remainingEnemies; // Переменная для хранения количества оставшихся противников
    
    public float maxHealth = 100f;
    private float currentHealth;

    public Image healthBar;

    void Start()
    {
        GenerateWave(waveSizes[currentWave], transform.position);
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot")) // Проверяем тег объекта
        {
            currentHealth -= 20;
            UpdateHealthBar();
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                remainingEnemies--;

                if (remainingEnemies == 0)
                {
                    currentWave++;

                    if (currentWave == waveSizes.Length)
                    {
                        Debug.Log("Game Over");
                        return;
                    }

                    GenerateWave(waveSizes[currentWave], transform.position);
                }
            }
        }
    }
    
    private void GenerateWave(int enemyCount, Vector3 startPosition)
    {
        remainingEnemies = enemyCount; // Устанавливаем количество оставшихся противников
        
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, startPosition, transform.rotation); // Создаем нового противника
            float randomX = Random.Range(-100f, 100f); // Устанавливаем случайную позицию для противника
            enemy.transform.position += new Vector3(randomX, 0, 0);
        }
    }
}