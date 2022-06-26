using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int _characterLevel = 0;
    public Type PlayerType;
    
    public UnityEvent OnCollect;
    public int MaxLevel = 36;
    public int cache = 0;
    
    public int CharacterLevel
    {
        get { return _characterLevel; }
    }

    public void LevelUp(int value)
    {
        if (Mathf.Abs(CharacterLevel + value) <= MaxLevel)
        {
            cache = _characterLevel;
            _characterLevel += value;
        }
        else
        {
            _characterLevel = MaxLevel;
        }
        OnCollect.Invoke();
    }

}
