using System;
using UnityEngine;

public class EnemyBase : BaseMoveForward
{
    [SerializeField] private int _scoreValue;
    public static  event Action<int> OnEnemyDeath;

    
    protected virtual void BroadcastScore()
    {
        OnEnemyDeath?.Invoke(_scoreValue);
    }
}