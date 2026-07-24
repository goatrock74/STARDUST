using UnityEngine;

public enum Item
{
    bucket,
    branch,
    food

}


[CreateAssetMenu(fileName = "ItemSO", menuName = "SO / item", order = 0)]
public class ItemSO : ScriptableObject
{
    public Sprite ItemAsset;
    [SerializeField] private Item item;
    public void UseItme()
    {
        switch (item)
        {
             case Item.bucket:
              Debug.Log("양동이");
              break;

                case Item.branch:
                Debug.Log("나뭇가지");
                break;

                case Item.food:
                Debug.Log("음식");
                break;
             

        }


    }

}
