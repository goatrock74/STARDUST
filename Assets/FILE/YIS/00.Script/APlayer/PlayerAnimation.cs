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

    //private void Update()
    //{
    //    if (playerMovement == null) return;

    //    if (playerMovement._moveDir.x > 0)
    //    {
    //        _sr.flipX = true;
    //    }
    //    else 
    //    {
    //        _sr.flipX = false; 
    //    }

    //}
}
