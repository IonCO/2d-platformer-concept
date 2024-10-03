using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _moveSpeed, _jumpForce = 30f;
    private bool _isJumping;
    private float _moveDirVal;
    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirVal = Input.GetAxis("Horizontal");
        _isJumping = Input.GetButton("Jump");  
        _moveDirection = new Vector2(_moveDirVal, 0f);
    }

    private void FixedUpdate()
    {
        if (_isJumping) Jumping();
        if (_moveDirection != Vector2.zero) Movement(_moveDirection);
    }

    private void Movement(Vector2 movedir)
    {
        _playerBody.velocity =  movedir * (_moveSpeed * Time.deltaTime);
    }

    private void Jumping()
    {
        _playerBody.AddForce(new Vector2(0, _jumpForce));
        _isJumping = false;
    }
}
