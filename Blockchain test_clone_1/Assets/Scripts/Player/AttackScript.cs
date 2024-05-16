using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;
using FishNet.Component.Animating;

public class AttackScript : NetworkBehaviour
{
    private Animator _animator;
    private NetworkAnimator _networkAnimator;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _networkAnimator = GetComponentInChildren<NetworkAnimator>();
    }   
    
    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        base.OnOwnershipClient(prevOwner);
        GetComponent<PlayerInput>().enabled = base.IsOwner;
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (!base.IsOwner) return;
        if (value.started)
        {
            _networkAnimator.SetTrigger("attack");
        }
        else if (value.canceled)
        {
            _networkAnimator.ResetTrigger("attack");
        }
    }
}
