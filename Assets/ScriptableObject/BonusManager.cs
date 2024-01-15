using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private Text BonusText;
    public float bonus = 0f;
    
    void Start()
    {
        UpdateBonusText();
    }
    
    void Update()
    {
        if (bonus == 100)
        {
            UseBonus();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot")) // Проверяем тег объекта
        {
            if (other.GetComponent<Collider>().gameObject.CompareTag("Enemy")) // Проверяем тег объекта, к которому прикреплен коллайдер
            {
                bonus += 2;
                UpdateBonusText();
            }
        }
    }
    
    private void UpdateBonusText()
    {
        BonusText.text = "BONUS: " + bonus.ToString();
    }

    private void UseBonus()
    {
        // Находим всех противников на карте
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        // Применяем урон к каждому противнику
        foreach (Enemy enemy in enemies)
        {
            enemy.TakeDamage(250); // Предполагается, что у врага есть метод TakeDamage для получения урона
        }

        // Сбрасываем бонус
        bonus = 0;
        UpdateBonusText();
    }
}