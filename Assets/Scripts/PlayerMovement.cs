using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private InputAction _moveControls;
    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirection = _moveControls.ReadValue<Vector2>();        
    }

    private void FixedUpdate()
    {
        if (_moveDirection != Vector2.zero) Movement(_moveDirection);
    }

    public void Movement(Vector2 movedir)
    {
        _playerBody.velocity =  movedir * _moveSpeed * Time.deltaTime;
    }

    public void Jumping()
    {
        _playerBody.AddForce(new Vector2(0,_moveSpeed));
    }
}
