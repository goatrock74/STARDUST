using UnityEngine;

public class Fire : MonoBehaviour, IFireOff
{
    public void FireOff()
    {
        gameObject.SetActive(false);
    }
}
