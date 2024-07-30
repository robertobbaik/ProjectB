using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Move
{
    public class CharacterMove : MonoBehaviour
    {
        public CharacterController characterController;
        public Animator animator;
        public float moveSpeed;
        private static readonly int Move = Animator.StringToHash("move");

        private void Start()
        {
            moveSpeed = 5.0f;
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 moveDirection = new(x, 0, y);
            
            characterController.SimpleMove(moveDirection * moveSpeed);
        }
    }
}
