using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float cameraSpeed;
    [SerializeField] Control _playerInput;
    [SerializeField] Rigidbody _rigidBody;

    protected Vector2 input_view;
    protected Vector2 input_move;
    private Vector3 move;
    private Vector3 direction;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] protected float movementSmoothing = 0.1f;
    private float yaw = 0f;

    [Header("Audio")] // To be added
    private AudioClip _walking;
    private AudioClip _pickup;


    void Awake()
    {
        _playerInput = new Control();
        _rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable(){
        _playerInput.Movement.Enable();
        _playerInput.Movement.View.performed += x => input_view = x.ReadValue<Vector2>().normalized;
        _playerInput.Movement.View.canceled += x => input_view = x.ReadValue<Vector2>().normalized;
    }

    private void OnDisable(){
        _playerInput.Movement.Disable();
        _playerInput.Movement.View.Disable();
    }
    
    void Update()
    {
        RotateMove();
    }

    void FixedUpdate()
    {
        //add if (paused) here
        Move();
    }

    private void Move(){
        input_move = _playerInput.Movement.Move.ReadValue<Vector2>();
        direction = (transform.rotation * Vector3.forward * input_move.y + transform.rotation * Vector3.right *input_move.x).normalized;
        move = direction * speed;
         Vector3 targetVelocity = new Vector3(move.x * Time.fixedDeltaTime * speed, _rigidBody.velocity.y, move.z * speed * Time.fixedDeltaTime);
        _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);

    }

    private void RotateMove(){
        yaw = input_view.normalized.x * Time.deltaTime * cameraSpeed;
        transform.Rotate(Vector3.up * yaw);
    }
}
