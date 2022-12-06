using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _roundText;

    private int _currentRound = 1;

    public static GameManager Instance
    {
        get;
        private set;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            throw new System.Exception($"Multiple game managers in the scene! {Instance} :: {this}");
        }

        Instance = this;
    }
    public void AddPoints(int pinValue)
    {
        _scoreText.text = $"Score: {pinValue}";
    }
}

