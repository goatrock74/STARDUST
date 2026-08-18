using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlanetRotating : MonoBehaviour
{
    float rotatingSpeed = 2f;

    float startAngle = 0;
    float targetAngle = 0;
    float t = 0;

    bool canRotateable = true;

    private void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame && canRotateable)
        {
            startAngle = transform.eulerAngles.z;
            targetAngle = startAngle + 90f;
            t = 0f;
            canRotateable = false;
            StartCoroutine(WaitInput());
        }

        if(t < 1)
        {
            t += Time.deltaTime * rotatingSpeed;

            float currentAngle = Mathf.Lerp(startAngle, targetAngle, t);

            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
        }
    }

    IEnumerator WaitInput()
    {
        yield return new WaitForSeconds(0.5f);
        canRotateable = true;
    }
}
