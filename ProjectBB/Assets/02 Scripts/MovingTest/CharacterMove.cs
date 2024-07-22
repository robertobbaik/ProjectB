using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Move
{
    public class CharacterMove : MonoBehaviour
    {
        public CharacterController characterController;
        public float moveSpeed;
        private void Start()
        {
            moveSpeed = 5.0f;
            characterController = GetComponent<CharacterController>();
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
