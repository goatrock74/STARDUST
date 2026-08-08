using UnityEngine;

namespace InGame
{
    public class ItemManger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IItem>(out IItem item))
            {
                item.Use(gameObject);
            }
        }
    }
}