using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManagerEnemy : MonoBehaviour
{
    public float fill = 100f;
    public Image bar;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lazerShot")
        {
            fill -= 20;
            bar.fillAmount = fill / 100;
        }
    }
}