using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemGet : MonoBehaviour
{

    [SerializeField] private Vector2 size;
    [SerializeField] LayerMask whatIsitem;

    private void LateUpdate()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, size, 0, whatIsitem);

        if (collider == null) return;

        if (Keyboard.current.eKey.wasPressedThisFrame && collider != null)
        {
            if(collider.TryGetComponent<IItem>(out IItem item))
            {
                item.GetItem();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
