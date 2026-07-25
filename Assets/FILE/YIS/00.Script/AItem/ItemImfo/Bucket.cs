using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bucket : MonoBehaviour
{

    [SerializeField] private GameObject Water;
    WaitForSeconds wait = new WaitForSeconds(1f);

    private void Update()
    {
        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            if(Water != null)
            {
                Water.SetActive(true);
                StartCoroutine(DisableWater());
            }
        }
    }

    IEnumerator DisableWater()
    {
        yield return wait;
        Water.SetActive(false);
    }

}
