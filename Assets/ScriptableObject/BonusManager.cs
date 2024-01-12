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
    
    // void Update()
    // {
        // if (bonus == 100)
        // {
            
        // }
    // }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot")) // Проверяем тег объекта
        {
            bonus += 5;
            UpdateBonusText();
        }
    }
    
    private void UpdateBonusText()
    {
        BonusText.text = "BONUS: " + bonus.ToString();
    }
    
    // private void 
    // 
        
    // }
}