using UnityEngine;

public class Ice : MonoBehaviour, IMeltable
{
    public void Melt()
    {
        gameObject.SetActive(false);
    }
}
