using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

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
        animator.SetBool("IsRun", true);
    }
    private void OnExitMoveState()
    {
        animator.SetBool("IsRun", false);
    }
}
