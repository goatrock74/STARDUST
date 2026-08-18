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

        if(playerMovement._moveDir.x < 0)
        {
            _sr.flipX = true;
        }
        else if(playerMovement._moveDir.x > 0)
        {
            _sr.flipX = false;
        }
    }


}