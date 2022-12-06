using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Pin hitPin = collision.gameObject.GetComponent<Pin>();

        if (hitPin != null)
        {
            GameManager.Instance.AddPoints(hitPin.PinValue);
        }
    }
}
