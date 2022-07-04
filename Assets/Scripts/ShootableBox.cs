using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    public int currentHealth = 3;
    public PlatformManager platformManager;
    private float intensity = 0.3f;
    private float temperature = 0.2f;

    void Start()
    {
        intensity = 0.5f;
        temperature = 0.5f/currentHealth;
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        gameObject.GetComponent<Renderer>().material.color = new Color(intensity, 0, 0, 0);
        intensity += temperature;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            platformManager.AddScore(1);
        }
    }

    void Update()
    {
        
    }
}
