using UnityEngine;

namespace InGame
{
    public class Planet_Gravity : MonoBehaviour
    {
        [Header("Planet")]
        [SerializeField] private GameObject planet;
        
        [Header("Gravity_Value")]
        [SerializeField] private float maxGravity;
        [SerializeField] private float maxGravityDist;

        public Vector2 GravityDir { get; private set;}

        private float lookAngle;//lookDirection을 라이안으로 바꿔서 플레이어가 행성에 표면과 평행을 이루게 만드는 변수
        private Vector3 lookDirection;//(planet-player)

        private Rigidbody2D rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float dist = Vector2.Distance(planet.transform.position, transform.position);
            if (dist < maxGravityDist)
            {
                GravityDir = planet.transform.position - transform.position;

                rigid.AddForce(GravityDir.normalized * 20f);
            }
            Debug.DrawRay(transform.position, GravityDir.normalized * 3f, Color.red);
        }



        private void Update()
        {
            Vector2 playerDir = planet.transform.position - transform.position;
            Vector2 dir_abs = new Vector2(Mathf.Abs(playerDir.x), Mathf.Abs(playerDir.y));

            // x와 y의 값 차이가 이 값보다 작으면 꼭짓점 부근으로 판단하고 방향 전환을 유예합니다.
            float threshold = 0.2f; // 게임 스케일에 따라 0.1 ~ 0.5 사이로 조절해보세요.

            // 두 값의 차이가 데드존보다 클 때만 각도를 재계산합니다.
            if (Mathf.Abs(dir_abs.x - dir_abs.y) > threshold)
            {
                int angle;
                if (dir_abs.x > dir_abs.y)
                {
                    angle = (playerDir.x < 0 ? -90 : 90);
                }
                else
                {
                    angle = (playerDir.y < 0 ? 0 : -180);
                }
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(planet.transform.position, maxGravityDist);
        }
    }
}