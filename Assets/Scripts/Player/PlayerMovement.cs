using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private StageManager stageManager;

    private void OnEnable()
    {
        PlayerMoveState.EnterMoveState += OnEnterMoveState;
        PlayerMoveState.ExitMoveState += OnExitMoveState;
    }
    private void OnDisable()
    {
        PlayerMoveState.EnterMoveState -= OnEnterMoveState;
        PlayerMoveState.ExitMoveState -= OnExitMoveState;
    }
    private void OnEnterMoveState()
    {
        agent.SetDestination(stageManager.GetNextTargetPosition());
    }
    private void OnExitMoveState()
    {
        agent.ResetPath();
    }
}
