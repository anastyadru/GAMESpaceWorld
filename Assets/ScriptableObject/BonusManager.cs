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
        if (other.CompareTag("lazerShot"))
        {
            if (other.GetComponent<Collider>().gameObject.CompareTag("Enemy"))
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
            if (lazerShot != null) // Проверяем, есть ли объект взаимодействия у пули
            {
                EnemyController enemy = lazerShot.GetComponent<EnemyController>(); // Получаем компонент скрипта врага
                
                if (enemy != null && enemy.fill >= 50) // Проверяем, что враг найден и у него есть достаточно здоровья
                {
                    enemy.fill -= 50; // Уменьшаем здоровье врага на 50
                }
            }
        }
    }
}