using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Text HealthText;
    
    public float health = 100f;

	void Start()
    {
        UpdateHealthText();
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot1")) // Проверяем тег объекта
        {
            health -= 5;
            HealthText.text = health.ToString();
        }
    }
    
    private void UpdateHealthText()
    {
        HealthText.text = "HEALTH: " + health.ToString();
    }
}