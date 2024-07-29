using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WayPoint Manager set new way point and have method for reached way point.
/// </summary>
public class StageManager : MonoBehaviour
{
    private List<IStage> stages = new List<IStage>();
    public static Action WayPointReached;

    private int nextWayPointNum;
    private int _nextWayPointNum
    {
        get
        {
            return nextWayPointNum;
        }
        set
        {
            if (value >= 0 || value < stages.Count)
            {
                nextWayPointNum = value;
            }
        }
    }
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out IStage stage))
            {
                stages.Add(stage);
            }
        }
    }
    private void OnEnable()
    {
        IStage.StageReached += OnReached;
    }
    private void OnDisable()
    {
        IStage.StageReached -= OnReached;
    }
    private void OnReached(IStage stage)
    {
        _nextWayPointNum++;
        WayPointReached?.Invoke();
    }

    public Vector3 NextWayPoint()
    {
        return stages[_nextWayPointNum].GetPosition();
    }
}