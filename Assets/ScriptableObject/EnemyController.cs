using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 250f; // Скорость перемещения
    private float smoothness = 3f; // Плавность движения

    private Vector3 targetPosition; // Целевая позиция
    
    public GameObject lazerShot1;
    public Transform lazerGun1;
    private float nextShotTime; // Время следующего выстрела
    
    public GameObject enemyPrefab; // Объявляем переменную для префаба противника
    private int currentWave = 0; // Текущая волна
    private int[] waveSizes = { 3, 5, 4, 6, 8, 12, 8 }; // Количество противников в каждой волне

    void Start()
    {
        GenerateNewTargetPosition();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 10f) // Если враг близок к целевой позиции
        {
            GenerateNewTargetPosition(); // Генерируем новую целевую позицию
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime); // Плавно перемещаем к целевой позиции
        
        if (Time.time > nextShotTime)
        {
            Shoot();
        }
    }

    void GenerateNewTargetPosition()
    {
        float randomX = Random.Range(-100f, 100f); // Генерируем случайное значение по оси X
        targetPosition = transform.position + new Vector3(randomX, 0, 0); // Изначально целевая позиция равна текущей позиции + случайное значение по оси X
        
        targetPosition.x = Mathf.Clamp(targetPosition.x, -500f, -100f); // Ограничиваем движение врага по горизонтали
    }
    
    void Shoot()
    {
        Instantiate(lazerShot1, lazerGun1.position, Quaternion.identity);
        nextShotTime = Time.time + 1.5f;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot")) // Проверяем тег объекта
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
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            
            // Устанавливаем случайную позицию для противника
            float randomX = Random.Range(-100f, 100f);
            enemy.transform.position += new Vector3(randomX, 0, 0);
        }
    }
}