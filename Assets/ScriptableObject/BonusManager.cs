using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private Text BonusText;
    public float bonus = 0f;
    
    public GameObject lazerShot;
    public Transform lazerGun;
    
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
        if (Input.GetButton("Fire2"))
        {
            // Проверяем, есть ли объект взаимодействия у пули
            if (lazerShot != null)
            {
                // Получаем компонент скрипта врага
                EnemyController enemy = lazerShot.GetComponent<EnemyController>();

                // Проверяем, что враг найден и у него есть достаточно здоровья
                if (enemy != null && enemy.fill >= 50)
                {
                    // Уменьшаем здоровье врага на 50
                    enemy.fill -= 50;
                }
            }
        }
    }
}