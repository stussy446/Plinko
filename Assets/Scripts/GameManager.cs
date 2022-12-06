using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Text")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _roundText;

    [Header("Delay Between Rounds")]
    [SerializeField] private float _secondsToWait = 2;

    private int _currentRound = 1;
    private int _currentScore = 0;

    public static GameManager Instance
    {
        get;
        private set;
    }

    public event Action OnNewRoundStart;

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
        _currentScore += pinValue;
        _scoreText.text = $"Score: {_currentScore}";
    }

    public void StartNextRoundCoroutine()
    {
        StartCoroutine(StartNextRound());
    }

    private IEnumerator StartNextRound()
    {
        yield return new WaitForSeconds(_secondsToWait);
        _currentRound++;
        _roundText.text = $"Round: {_currentRound}";

        ResetScore();
        OnNewRoundStart?.Invoke();
    }

    private void ResetScore()
    {
        _currentScore = 0;
        _scoreText.text = $"Score: {_currentScore}";
    }
}

