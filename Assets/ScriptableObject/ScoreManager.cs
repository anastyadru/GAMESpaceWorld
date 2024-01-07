using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;
    [SerializeField] private Text ScoreText;
    
    public float score;
    public float highscore;
}