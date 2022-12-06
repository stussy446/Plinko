using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.OnNewRoundStart += NewRoundStarted;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnNewRoundStart -= NewRoundStarted;
    }

    /// <summary>
    /// if the collision was a pin, calls GameManager to add pins point value to total points and update text 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Pin hitPin = collision.gameObject.GetComponent<Pin>();

        if (hitPin != null)
        {
            GameManager.Instance.AddPoints(hitPin.PinValue);
        }
    }

    /// <summary>
    /// Begins process of starting then next round (only trigger collider in the game is at the bottom of the board)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.StartNextRoundCoroutine();
    }
    private void NewRoundStarted()
    {
        Destroy(gameObject);
    }

}
