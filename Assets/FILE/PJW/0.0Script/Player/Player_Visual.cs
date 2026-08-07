using UnityEngine;

namespace InGame
{
    public class Player_Visual : MonoBehaviour
    {
        [Header("Planet")]
        [SerializeField] private GameObject planet;
        
        
        private Vector2 lookDirection;
        private float lookAngle;

        void Update()
        {
            lookDirection = planet.transform.position - transform.position;
            float rawAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            lookAngle = (Mathf.Round(rawAngle / 90) + 1) * 90;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        }
    }
}