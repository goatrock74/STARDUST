using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    private float _speed = 10f;
    public Vector2 _moveDir;
    


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveDir * _speed;
    }


    private void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>();
    }
}
