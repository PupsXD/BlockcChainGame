using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag != "Player") return;
      
      Health health = other.gameObject.GetComponent<Health>();
      if (health != null)
      {
         health.TakeDamage(10);
         
      }
   }
}
