using UnityEngine;

/// <summary>
/// On state enter RunState started Player moving to point in Update method.
/// </summary>
public class PlayerRunState : PlayerBaseState
{
    private PlayerStateManager playerStateManager;
    private PlayerMovement playerMovement;

    public PlayerRunState(PlayerStateManager _playerStateManager, PlayerMovement _playerMovement)
    {
        playerStateManager = _playerStateManager;
        playerMovement = _playerMovement;
    }

    public override void EnterState()
    {
        Debug.Log("Enter runState");
        StageManager.WayPointReached += OnWayPointReached;
        //when next point reached switch state to stay state
    }

    public override void ExitState()
    {
        Debug.Log("Exit runState");
        StageManager.WayPointReached -= OnWayPointReached;
        //
    }

    public override void UpdateState()
    {
        playerMovement.MoveToPoint();
        //stateManager.SwitchState(stateManager.stayState);
    }

    private void OnWayPointReached()
    {
        playerStateManager.SwitchState(playerStateManager.stayState);
        //start run to point
    }
}
