using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHealth = 100;
    
    private int _currentHealth;
    
    private HealthBar _healthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponent<HealthBar>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
            
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
