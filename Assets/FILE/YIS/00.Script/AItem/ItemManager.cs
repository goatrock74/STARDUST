using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public bool getBucket = false;

    public bool getBranch = false;

    [SerializeField] GameObject Branch;
    [SerializeField] GameObject Bucket;



    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {


        if(getBucket && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            if (Branch != null) 
            Branch.SetActive(false);
            
            Bucket.SetActive(true);
        }

        if(getBranch && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            if (Bucket != null)
            Bucket.SetActive(false);
            
            Branch.SetActive(true);
        }
    }
}
