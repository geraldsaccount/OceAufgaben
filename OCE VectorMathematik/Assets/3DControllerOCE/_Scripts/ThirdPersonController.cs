// Author: gérald
// Date: 07.12.2022

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ControllerOCE {
    public class ThirdPersonController : MonoBehaviour {
        #region Serialized Fields
        [SerializeField] private Transform _camAnchorHorizontal;
        [SerializeField] private Transform _camAnchorVertical;
        [SerializeField] private float _cameraSpeedHorizontal;
        [SerializeField] private float _cameraSpeedVertical;
        [SerializeField] private float _minVerticalRotation;
        [SerializeField] private float _maxVerticalRotation;
        [SerializeField] private Transform _modelTransform;
        [SerializeField] private float _smoothTime;

        [SerializeField] private float _speed;
        [SerializeField] [Range(1.0f, 5.0f)] private float _runMultiplier;
        [SerializeField] private float _minJumpForce;
        [SerializeField] private float _maxJumpForce;
        [SerializeField] private float _jumpChargeDuration;

        [SerializeField] private LayerMask _groundLayer;
        #endregion

        private bool _isGrounded;
        private bool _isRunning;
        private float _jumpChargeValue;
        private Vector2 _lookInput;

        private Vector2 _moveInput;

        private Rigidbody _rigidbody;
        private Vector3 _smoothVelocity;

        #region Event Functions
        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            RotateCamera();
        }

        private void FixedUpdate() {
            Move();
        }

        private void OnCollisionStay(Collision collisionInfo) {
            var collisionLayer = collisionInfo.gameObject.layer;
            if (_groundLayer == (_groundLayer | (1 << collisionLayer))) {
                _isGrounded = true;
                CancelInvoke(nameof(GroundReset));
                Invoke(nameof(GroundReset), 0.15f);
            }
        }
        #endregion

        private void OnMove(InputValue value) {
            _moveInput = value.Get<Vector2>();
        }

        private void OnRun(InputValue value) {
            _isRunning = value.isPressed;
        }

        private void OnJump(InputValue value) {
            if (value.isPressed && _isGrounded) StartCoroutine(JumpCharge());
            else if (!value.isPressed && _isGrounded) Jump();
        }

        private void OnLook(InputValue value) {
            _lookInput = value.Get<Vector2>();
        }

        private void Move() {
            var moveVelocity = new Vector3(_moveInput.x, 0f, _moveInput.y) * _speed;
            moveVelocity = _camAnchorHorizontal.TransformDirection(moveVelocity);

            if (_moveInput != Vector2.zero) _modelTransform.forward = Vector3.SmoothDamp(_modelTransform.forward, moveVelocity.normalized, ref _smoothVelocity, _smoothTime);

            moveVelocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = moveVelocity;
        }

        private IEnumerator JumpCharge() {
            var counter = 0f;

            while (counter <= _jumpChargeDuration) {
                var t = counter / _jumpChargeDuration;

                _jumpChargeValue = Mathf.Lerp(_minJumpForce, _maxJumpForce, t);

                if (!_isGrounded) yield break;

                yield return null;
                counter += Time.deltaTime;
            }

            _jumpChargeValue = _maxJumpForce;
            Jump();
        }

        private void Jump() {
            StopCoroutine(JumpCharge());
            _rigidbody.AddForce(Vector3.up * _jumpChargeValue, ForceMode.Impulse);

            _jumpChargeValue = 0f;
        }

        private void GroundReset() {
            _isGrounded = false;
        }

        private void RotateCamera() {
            _camAnchorHorizontal.Rotate(Vector3.up * (_lookInput.x * _cameraSpeedHorizontal));
            _camAnchorVertical.Rotate(Vector3.right * (_lookInput.y * _cameraSpeedVertical));
            _camAnchorVertical.localRotation = Quaternion.Euler(Vector3.right * Mathf.Clamp(_camAnchorVertical.localRotation.eulerAngles.x, _minVerticalRotation, _maxVerticalRotation)) ;
        }
    }
}
