using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables: Movement
    private CharacterController _characterController;
    [SerializeField] private Movement movement;
    private Vector2 _input;
    private Vector3 _direction;
    #endregion

    #region Variables: Camera
    private Camera _mainCamera;
    public int fov;
    #endregion

    #region Variables: Gravity
    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;
    #endregion

    #region Variables: Jumping
    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int maxNumberOfJumps = 1;
    #endregion
    #region Variables: Audio
    public AudioSource _audioSource;
    public AudioClip footstep;
    #endregion
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        _mainCamera.fieldOfView = fov;
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(playFootsteps());
    }
    private void Update()
    {
        ApplyGravity();
        ApplyMovement();
    }
    private bool IsGrounded() => _characterController.isGrounded;
    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }
    private void ApplyMovement()
    {
        var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;
        movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);
        _mainCamera.fieldOfView = Mathf.MoveTowards(_mainCamera.fieldOfView, movement.isSprinting && movement.currentSpeed > 0 ? fov * 1.2f : fov, 1);
        _direction = transform.forward * _input.y + _direction.y * transform.up + transform.right * _input.x;
        _characterController.Move(_direction * movement.currentSpeed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        //_direction = new Vector3(_input.x, 0.0f, _input.y);
        //_direction = transform.forward * _input.y + transform.up * 0 + transform.right * _input.x;
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        movement.isSprinting = context.started || context.performed;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;
        _velocity = jumpPower;
    }
    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);
        _numberOfJumps = 0;
    }

    IEnumerator playFootsteps()
    {
        _audioSource.clip = footstep;
        while (true)
        {
            _audioSource.volume = (movement.currentSpeed - movement.speed + 1) / (movement.speed * movement.multiplier);
            if (_input.magnitude > 0 && IsGrounded()) _audioSource.Play();
            float stepDelay = movement.isSprinting ? 0.3f : 0.5f;
            yield return new WaitForSeconds(stepDelay);
        }
    }
}

[Serializable]
public struct Movement
{
    public float speed;
    public float multiplier;
    public float acceleration;

    [HideInInspector] public bool isSprinting;
    public float currentSpeed;
}