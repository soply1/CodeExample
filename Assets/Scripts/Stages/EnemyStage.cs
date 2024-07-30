using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyStage : MonoBehaviour, IStage 
{
    [SerializeField] private TargetPoint targetPoint;
    [SerializeField] private EnemyGroup enemyGroup;
    [SerializeField] private GameObject enemyOverlay;

    public static Action StageReached;
    public static Action StageCompleted;

    public TargetPoint TargetPoint { get { return targetPoint; } }

    private void OnEnable()
    {
        targetPoint.TargetPointReached += OnTargetPointReached;
        enemyGroup.AllEnemiesDead += OnAllEnemiesDead;
    }
    private void OnDisable()
    {
        targetPoint.TargetPointReached -= OnTargetPointReached;
        enemyGroup.AllEnemiesDead -= OnAllEnemiesDead;
    }
    private void OnTargetPointReached()
    {
        enemyOverlay.SetActive(true);
        enemyGroup.ActivateEnemiesColliders();
        StageReached?.Invoke();
    }
    private void OnAllEnemiesDead()
    {
        StageCompleted?.Invoke();
    }
}
