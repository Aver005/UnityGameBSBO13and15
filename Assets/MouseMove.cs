using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float _mouseSensitivity = 0.4f;
    public float _moveSpeed = 10f;
    public GameObject _capsule;
    public CharacterController _characterController;
    public Rigidbody _capsuleRigidbody;
    private Vector3 _mousePreveousePos;
    private float _rotationX;
    private float _rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Rotate();
        Move();
    }

    void Rotate()
    {
        Vector3 _mouseDelta = Input.mousePosition - _mousePreveousePos;
        _mousePreveousePos = Input.mousePosition;

        _rotationX -= _mouseDelta.y * _mouseSensitivity;
        _rotationY += _mouseDelta.x * _mouseSensitivity;

        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0f);
    }

    void Move()
    {
        /*
        // Get Horizontal and Vertical Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the Direction to Move based on the tranform of the Player
        Vector3 moveDirectionForward = transform.forward * verticalInput * Time.deltaTime;
        Vector3 moveDirectionSide = transform.right * horizontalInput * Time.deltaTime;

        // Apply Movement to Player
        _characterController.Move((moveDirectionForward + moveDirectionSide).normalized * _moveSpeed);
        */

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveBy = transform.right * x + transform.forward * z;

        float actualSpeed = _moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed *= 1.4f;
        }

        _capsuleRigidbody.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime);
    }
}
