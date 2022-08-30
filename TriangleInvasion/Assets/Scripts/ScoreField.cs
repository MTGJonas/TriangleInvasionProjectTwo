using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreField : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    private int _totalScore;

    private void Start()
    {
        EnemyBase.OnEnemyDeath += HandleEnemyDeathScore;
    }

    private void OnDestroy()
    {
        EnemyBase.OnEnemyDeath -= HandleEnemyDeathScore;
    }

    private void HandleEnemyDeathScore(int addedScore)
    {
        _totalScore += addedScore;
        _textField.SetText(_totalScore.ToString());
    }
}
