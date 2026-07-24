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
                Bucket();
              break;

                case Item.branch:
                Branch();
                break;

                case Item.food:
                Food();
                break;
             

        }


    }

    void Bucket()
    {
        ItemManager.instance.getBucket = true;
    }

    void Branch()
    {
        ItemManager.instance.getBranch = true;
    }


    void Food()
    {
        Debug.Log("È¸º¹");
    }

}
