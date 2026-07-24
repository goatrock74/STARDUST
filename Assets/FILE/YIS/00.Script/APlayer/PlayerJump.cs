using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] GravityedThing Gravityed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Vector2 size;
    [SerializeField] LayerMask whatIsGround;
    WaitForSeconds wait = new WaitForSeconds(0.2f);


    private void Awake()
    {
        Gravityed = GetComponentInParent<GravityedThing>();
    }

    private void Update()
    {
        
        Collider2D jum = Physics2D.OverlapBox(transform.position, size, 0 ,whatIsGround);

        if (jum == null) return;

        if (jum != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Gravityed.gravityPower *= -1;
            StartCoroutine(JumpOver());
        }
    }

    
    



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, size);
    }

    IEnumerator JumpOver()
    {
        yield return wait;
        Gravityed.gravityPower *= -1;
    }
}