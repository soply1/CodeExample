using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStage : MonoBehaviour, IStage
{
    [SerializeField] private WayPoint wayPoint;

    private void OnEnable()
    {
        wayPoint.Reached += OnWayPointReached;
    }
    private void OnDisable()
    {
        wayPoint.Reached -= OnWayPointReached;
    }
    private void OnWayPointReached()
    {
        Debug.Log("Enemy stage Reached");
        IStage.StageReached?.Invoke(this);
    }
    public Vector3 GetPosition()
    {
        return wayPoint.transform.position;
    }

}
