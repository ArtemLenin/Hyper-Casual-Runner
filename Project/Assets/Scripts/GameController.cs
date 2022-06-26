using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instanse;
    public UnityEvent OnGameStarted;
    public GameObject Player;
    
    private bool _gameStarted = false;
    
    public bool GameStarted { get { return _gameStarted; }}
    
    private void Awake()
    {
        Instanse = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnGameStarted.Invoke();
        }
    }

    public void StartGame()
    {
        _gameStarted = true;
    }
}
