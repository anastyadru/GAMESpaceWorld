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
    
    private string highScoreKey = "HighScore";

	void Start()
    {
        highscore = PlayerPrefs.GetFloat(highScoreKey, 0f);
        UpdateScoreText();
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
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    score += enemy.health;
                    UpdateScoreText();
                }
            }
        }
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score.ToString();
        
        if (score > highscore)
        {
            highscore = score;
            HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
        }
    }
}