using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private Vector2 size;
    [SerializeField] LayerMask whatIsGround;

    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        
        Collider2D jum = Physics2D.OverlapBox(transform.position, size, 0 ,whatIsGround);

        if (jum == null) return;

        if (jum != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _rb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, size);
    }
}