using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Spawn Game Object")]
    [SerializeField] private GameObject _ballPrefab;

    [SerializeField] private float _zMousePos = 13.4f;

    private int _ballCount = 0;

    private void OnEnable()
    {
        GameManager.Instance.OnNewRoundStart += ResetBallCount;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnNewRoundStart -= ResetBallCount;
    }

    private void ResetBallCount()
    {
        _ballCount = 0;
    }

    private void Update()
    {
        SpawnBall();
    }

    /// <summary>
    /// Spawns Ball at the mouse position when clicked, if there are no other balls currently in the scene 
    /// </summary>
    private void SpawnBall()
    {
        if (Input.GetButtonDown("Fire1") && _ballCount == 0)
        {
            Vector3 mousePos = GenerateMousePosition();

            Instantiate(_ballPrefab, mousePos, Quaternion.identity);
            _ballCount++;
        }
    }

    /// <summary>
    /// Generates Formatted MousePosition based on formatting the raw position with Camera.main.ScreenToWorldPoint
    /// </summary>
    /// <returns></returns>
    private Vector3 GenerateMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _zMousePos;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void OnNewRoundStart()
    {
        // TODO:, set _ballCount back to 0 whenever the new round starts, probably fire off an event from the GameManager
    }
}
