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
        
    }

    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lazerShot1")
        {
            health -= 5;
            Health.healthAmount = health / 100;
        }
    }
}