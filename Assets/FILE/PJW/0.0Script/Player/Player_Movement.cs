using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


namespace InGame
{
    public class Player_Movement : MonoBehaviour
    {
        [Header("Speed")]
        [Min(1f)]
        [SerializeField] private float speed;


        [Header("Planet_Gravity")]
        [SerializeField] private Planet_Gravity pg_cs;


        [Header("Player_Visual")]
        [SerializeField] private Player_Visual pv_cs;


        private Vector2 Input;
        private Vector2 playerDir;
        private Vector2 moveDir;
        private Rigidbody2D rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            playerDir = pg_cs.GravityDir;

            Vector2 playerDir_abs = new Vector2(Mathf.Abs(pg_cs.GravityDir.x), Mathf.Abs(pg_cs.GravityDir.y));
            moveDir = Vector2.zero;

            if (playerDir_abs.x > playerDir_abs.y)
            {
                // 플레이어가 좌/우 측면에 있을 때 -> 상/하(y) 입력 사용
                moveDir = new Vector2(0, Input.y);
            }
            else
            {
                // 플레이어가 상/하 측면에 있을 때 -> 좌/우(x) 입력 사용
                moveDir = new Vector2(Input.x, 0);
            }

            // 2. 방향 정규화 (입력이 작을 때 급격히 커지는 문제 방지)
            Vector2 targetDirection = moveDir.magnitude > 0.01f ? moveDir.normalized : Vector2.zero;

            // 3. 목표 속도 계산 및 부드러운 이동 (입력이 없을 땐 Lerp를 통해 0으로 감속)
            Vector2 targetVelocity = targetDirection * speed;
            rigid.linearVelocity = Vector2.Lerp(rigid.linearVelocity, targetVelocity, 15f * Time.fixedDeltaTime);
        }

        private void OnMove(InputValue value)
        {
            Input = value.Get<Vector2>();
        }

        private void LateUpdate()
        {
            pv_cs.Visual(playerDir,moveDir);
        }
    }
}