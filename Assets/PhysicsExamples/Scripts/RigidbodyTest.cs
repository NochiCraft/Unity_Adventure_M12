using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _isJumpKeyPressed;
    private bool _isWalkKeyPressed;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.useGravity = false;
        //_rigidbody.AddForce();
        Application.targetFrameRate = 200; // Ограничение FPS
        //Application.targetFrameRate = 30;
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.F))
        //    _rigidbody.AddForce(Vector3.forward * 10);

        //if (Input.GetKeyDown(KeyCode.Space))
        //    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.F))
            _isWalkKeyPressed = true;

        if (Input.GetKeyDown(KeyCode.Space))
            _isJumpKeyPressed = true;
    }

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.F))
        //    _rigidbody.AddForce(Vector3.forward * 10);

        //if (Input.GetKeyDown(KeyCode.Space))
        //    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);

        if (_isWalkKeyPressed)
        {
            _rigidbody.AddForce(Vector3.forward * 10, ForceMode.Impulse);
            _isWalkKeyPressed = false;
        }

        if (_isJumpKeyPressed)
        {
            _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            _isJumpKeyPressed = false;
        }
    }
}
