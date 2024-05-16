using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private Image healthbar;


   public void UpdateHealthBar(int currentHealth, int maxHealth)
   {
      healthbar.fillAmount = (float)currentHealth / maxHealth;
   }
}
