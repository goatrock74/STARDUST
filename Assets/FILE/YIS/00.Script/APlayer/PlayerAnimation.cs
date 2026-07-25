using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    
    SpriteRenderer _sr;

    Animator _ani;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        _sr = GetComponent<SpriteRenderer>();
        _ani = GetComponent<Animator>();
    }

    

    private void Update()
    {
        if (playerMovement == null) return;

        _ani.SetFloat("Speed", playerMovement._moveDir.magnitude);

    }

    private void FixedUpdate()
    {
        if (playerMovement == null) return;

        if (playerMovement._moveDir.x * -transform.rotation.z < 0)
        {
            _sr.flipX = true;
        }
        else if (playerMovement._moveDir.x * -transform.rotation.z > 0)
        {
            _sr.flipX = false;
        }
    }

}