using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackScript : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }   

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            _animator.SetTrigger("attack");
        }
        else if (value.canceled)
        {
            _animator.ResetTrigger("attack");
        }
    }
}
