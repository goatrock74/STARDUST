using UnityEngine;

namespace InGame
{
    public class Player_Visual : MonoBehaviour
    {
        private SpriteRenderer sprite;
        private Animator animator;

        private int hash_walk;
        private int hash_stand;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            hash_walk = Animator.StringToHash("Walk");
            hash_stand = Animator.StringToHash("Stand");
        }

        public void Visual(Vector2 Direction,Vector2 input)
        {
            Vector2 player_way = new Vector2(Mathf.Abs(Direction.x),Mathf.Abs(Direction.y));
            if (input != Vector2.zero)
            {
                if (player_way.x > player_way.y)
                {
                    if (Direction.x>0)
                    {
                        //플레이어의 위치는 왼쪽
                        sprite.flipX = input.y > 0 ? false: true;
                    }
                    else
                    {
                        //플레이어의 위치는 오른쪽
                        sprite.flipX = input.y < 0 ? false: true;
                    }
                }
                else
                {
                    if (Direction.y>0)
                    {
                        //플레이어의 위치는 아래
                        sprite.flipX = input.x > 0 ? true : false;

                    }
                    else
                    {
                        //플레이어의 위치는 위
                        sprite.flipX = input.x < 0 ? true : false;
                    }
                }
                animator.Play(hash_walk);
            }
            else
            {
                animator.Play(hash_stand);
            }
        }
    }
}