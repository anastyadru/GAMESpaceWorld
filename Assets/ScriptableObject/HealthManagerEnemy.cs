using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManagerEnemy : MonoBehaviour
{
    // [SerializeField] private Text HealthTextEnemy;
    
    public Image bar;
    public float fill;

    void Start()
    {
        fill = 100f;
    }

    void Update()
    {
        bar.fillAmount = fill;
    }
}