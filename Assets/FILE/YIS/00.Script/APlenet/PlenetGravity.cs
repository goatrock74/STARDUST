using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlenetGravity : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGravityable;
    public float gravity = 13;
    [SerializeField] private float Radius = 30f;
    public List<Collider2D> AttractedObject = new List<Collider2D>();
    [HideInInspector] public Transform _attractorTransform;

    private void Awake()
    {
        _attractorTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        SetAttractedObject();
    }

    private void FixedUpdate()
    {
        AttractObject();
    }

    void SetAttractedObject()
    {
        AttractedObject = Physics2D.OverlapCircleAll(_attractorTransform.position, Radius, whatIsGravityable).ToList();
    }

    private void AttractObject()
    {
        for(int i = 0; i < AttractedObject.Count; i++)
        {
            AttractedObject[i].GetComponent<GravityedThing>().Attract(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

}
