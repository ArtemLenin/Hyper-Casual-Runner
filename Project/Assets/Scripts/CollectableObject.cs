using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Type
{
    Scientist,
    Sportsman
}

public class CollectableObject : MonoBehaviour
{
    
    [SerializeField] private int _value = 2;
    [SerializeField] private Type _objectType;

    private ScoreSystem _score;

    private void Start()
    {
        _score = GameController.Instanse.Player.GetComponent<ScoreSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_score.PlayerType == _objectType) ChangeScore(_value);
        else ChangeScore(-_value);
    }

    private void ChangeScore(int value)
    {
        _score.LevelUp(value);
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}