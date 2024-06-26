using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : NetworkBehaviour
{
   [SerializeField] private float _speed;
   
   private Vector2 _userInput;
   
   private Rigidbody2D _rb;
   
   private Animator _animator;

   private bool _flipped = false;

   [SerializeField] private Transform mainTransform;
   
   private void Awake()
   {
      _rb = GetComponent<Rigidbody2D>();
      _animator = GetComponentInChildren<Animator>();
   }

   public override void OnOwnershipClient(NetworkConnection prevOwner)
   {
      base.OnOwnershipClient(prevOwner);
      GetComponent<PlayerInput>().enabled = base.IsOwner;
   }


   private void FixedUpdate()
   {
      if (!base.IsOwner) return;
      Move();  
   }
   
   public void OnMove(InputAction.CallbackContext value)
   {
      _userInput = value.ReadValue<Vector2>();
      _animator.SetFloat("speed", _userInput.magnitude);
      if (_userInput.x < 0 && !_flipped)
      {
         _flipped = true;
      }
      else if (_userInput.x > 0 && _flipped)
      {
         _flipped = false;
      }
      mainTransform.localScale = new Vector3(_flipped ? -1 : 1, 1, 1);
   }

   private void Move()
   {
      _rb.MovePosition(_rb.position + _userInput * _speed * Time.fixedDeltaTime); 
   }
   
   
}
