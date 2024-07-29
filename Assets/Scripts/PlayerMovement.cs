using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private StageManager wayPointManager;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint()
    {
        agent.SetDestination(wayPointManager.NextWayPoint());
    }
}
