// Author: gérald
// Date: 30.11.2022

using System;
using UnityEngine;

namespace DefaultNamespace {
    public class DotTest : MonoBehaviour {
        [SerializeField] private Transform other;
        [SerializeField, Range(-1, 1)] private float viewCone;
        private Vector3 otherDirection;

        private void Update() {
            otherDirection = (other.position - transform.position).normalized;
            Debug.Log(Vector3.Dot(transform.forward, otherDirection));
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);
            var dot = Vector3.Dot(transform.forward, otherDirection);
            Gizmos.color = dot > viewCone ? Color.magenta : Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + otherDirection);
        }
    }
}
