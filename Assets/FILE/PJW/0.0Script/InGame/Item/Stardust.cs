using UnityEngine;

namespace InGame
{
    public class Stardust : MonoBehaviour,IItem
    {
        public void Use(GameObject target)
        {
            Debug.Log("점수 획득");
        }
    }
}