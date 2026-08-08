using UnityEngine;

public enum Stardust
{
    bucket,
    branch,
    food

}


[CreateAssetMenu(fileName = "ItemSO", menuName = "SO / item", order = 0)]
public class ItemSO : ScriptableObject
{
    public Sprite ItemAsset;
    [SerializeField] private Stardust item;
    public void UseItme()
    {
        switch (item)
        {
             case Stardust.bucket:
                Bucket();
              break;

                case Stardust.branch:
                Branch();
                break;

                case Stardust.food:
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
