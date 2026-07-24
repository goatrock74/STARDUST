using UnityEngine;

public class ItemGetScript : MonoBehaviour, IItem
{
    [SerializeField] private ItemSO ItemSO;
    
    public void GetItem()
    {
        ItemSO.UseItme();
    }
}
