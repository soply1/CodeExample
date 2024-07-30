using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState currentState;

    public PlayerStayState StayState { get; private set; }
    public PlayerMoveState RunState { get; private set; }
    public PlayerShootState EnemyState { get; private set; }

    private void Awake()
    {
        StayState = new PlayerStayState(this);
        RunState = new PlayerMoveState(this);
        EnemyState = new PlayerShootState(this);
    }
    void Start()
    {
        SwitchState(StayState);
    }
    private void OnDisable()
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
    }

    public void SwitchState(PlayerBaseState state)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = state;
        currentState.EnterState();
    }
}