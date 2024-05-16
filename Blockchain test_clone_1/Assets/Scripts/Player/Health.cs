using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class Health : NetworkBehaviour
{
    private int _maxHealth = 100;
    
    public int _currentHealth;
    
    private HealthBar _healthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponent<HealthBar>();
    }

    // public void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         TakeDamage(10);
    //         
    //     }
    // }

    public void UpdateHealth(int health)
    {
        _currentHealth = health;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        ObserversUpdateHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    [ObserversRpc (BufferLast = true)]
    private void ObserversUpdateHealth(int health)
    {
        _currentHealth = health;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
