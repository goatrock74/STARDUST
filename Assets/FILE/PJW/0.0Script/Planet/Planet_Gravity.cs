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
            lookDirection = planet.transform.position - transform.position;
            float rawAngle = Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg;

            lookAngle = (Mathf.Round(rawAngle/90)+1)*90;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(planet.transform.position, maxGravityDist);
        }
    }
}