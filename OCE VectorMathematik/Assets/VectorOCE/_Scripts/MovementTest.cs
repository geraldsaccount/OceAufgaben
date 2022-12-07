// Author: gérald
// Date: 30.11.2022

using System;
using UnityEngine;

namespace DefaultNamespace {
    public class MovementTest : MonoBehaviour {
        [SerializeField] private float moveDistance;
        [SerializeField] private float moveSpeed;
        private Vector3 moveDirection = Vector3.right;

        private void Update() {
            if (transform.position.x > moveDistance ) {
                moveDirection = Vector3.left;
            }
            else if (transform.position.x < -moveDistance) {
                moveDirection = Vector3.right;
            }
            transform.position += (Time.deltaTime * moveSpeed) * moveDirection;
        }
    }
}
