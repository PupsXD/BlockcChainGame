using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class Damager : NetworkBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!base.IsOwner) return;
      if (other.gameObject.tag != "Player") return;
      
      Health health = other.gameObject.GetComponent<Health>();
      if (health != null)
      {
         ServerDamager(health);
         
      }
   }
   
   [ServerRpc]
   private void ServerDamager(Health opponentsHealth)
   {
      opponentsHealth.UpdateHealth(opponentsHealth._currentHealth - 10);
   }
}
