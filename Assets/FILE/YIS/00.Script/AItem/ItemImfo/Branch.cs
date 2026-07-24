using UnityEngine;

public class Branch : MonoBehaviour
{
   [SerializeField] private bool _isFireed = false;
   [SerializeField] Vector2 size;
    [SerializeField] LayerMask whatCanInteractWithFire;

    private void OnEnable()
    {
        _isFireed = false;
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, size ,transform.rotation.z, whatCanInteractWithFire);
        if (collider == null) return;

        if(collider != null && collider.CompareTag("Fire"))
        {
            _isFireed = true;
        }

        if(_isFireed && collider != null)
        {
            if(collider.TryGetComponent<IMeltable>(out IMeltable meltable))
            {
                meltable.Melt();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.indianRed;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void OnDisable()
    {
        _isFireed = false;
    }
}
