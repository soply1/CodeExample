using UnityEngine;

/// <summary>
/// On state enter StayState subscribe at Left Mouse Button Click and switch state when Mouse is been clicked.
/// </summary>
public class PlayerStayState : PlayerBaseState
{
    private PlayerStateManager playerStateManager;

    public PlayerStayState(PlayerStateManager _playerStateManager)
    {
        playerStateManager = _playerStateManager;
    }

    public override void EnterState()
    {
        Debug.Log("Enter stayState");
        PlayerInputManager.MouseClicked += OnMouseClicked;
    }

    public override void ExitState()
    {
        Debug.Log("Exit stayState");
        PlayerInputManager.MouseClicked -= OnMouseClicked;
    }

    public override void UpdateState()
    {
        //stateManager.SwitchState(stateManager.runState);
    }

    private void OnMouseClicked()
    {
        playerStateManager.SwitchState(playerStateManager.runState);
    }

}