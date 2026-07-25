using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    LayerMask whatIsFire;

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, size, 0, whatIsFire);

        if (collider == null) return;

        if(collider != null)
        {
            if(collider.TryGetComponent<IFireOff>(out IFireOff fireOff))
            {
                fireOff.FireOff();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.aquamarine;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
