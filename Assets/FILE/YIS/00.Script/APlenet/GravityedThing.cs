using UnityEngine;

public class GravityedThing : MonoBehaviour
{
    // 대충 중력에 영항을 받는거

    [SerializeField] private bool rotateToCenter;
    [SerializeField] PlenetGravity plenetGravity;
    [SerializeField] public float gravityPower = 100f;

    Transform m_transform;
    Collider2D _cc;
    Rigidbody2D _rb;

    private void Start()
    {
        m_transform = GetComponent<Transform>();
        _cc = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(plenetGravity != null)
        {
            if(!plenetGravity.AttractedObject.Contains(_cc))
            {
                plenetGravity = null;
                return;
            }
            if (rotateToCenter) RotateToCenter();
            _rb.gravityScale = 0f;
        }
        else
        {
            _rb.gravityScale = 1f;
        }
    }

    public void Attract(PlenetGravity plenetGravityObj)
    {
        Vector2 attractionDir = ((Vector2)plenetGravityObj._attractorTransform.position - _rb.position).normalized;
        _rb.AddForce(attractionDir * -plenetGravityObj.gravity * gravityPower * Time.fixedDeltaTime);

        if (plenetGravity == null) plenetGravity = plenetGravityObj;
    }

    private void RotateToCenter()
    {
        if (plenetGravity != null)
        {
            Vector2 distanceVector = (Vector2)plenetGravity._attractorTransform.position - (Vector2)m_transform.position;
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
            m_transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }
}
