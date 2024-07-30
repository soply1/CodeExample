using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishStage : MonoBehaviour, IStage
{
    [SerializeField] private TargetPoint targetPoint;

    public static Action StageReached;

    public TargetPoint TargetPoint { get { return targetPoint; } }

    private void OnEnable()
    {
        targetPoint.TargetPointReached += OnTargetPointReached;
    }
    private void OnDisable()
    {
        targetPoint.TargetPointReached += OnTargetPointReached;
    }
    private void OnTargetPointReached()
    {
        StageReached?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}