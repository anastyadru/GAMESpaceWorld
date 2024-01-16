using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HighScoreText;
    
    public float score = 0f;
    public float highscore = 0f;

	void Start()
    {
        UpdateScoreText();
        // UpdateHighScoreText;
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazerShot")) // Проверяем тег объекта
        {
            if (other.GetComponent<Collider>().gameObject.CompareTag("Enemy")) // Проверяем тег объекта, к которому прикреплен коллайдер
            {
                score += 2;
                UpdateScoreText();
            }
        }
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}