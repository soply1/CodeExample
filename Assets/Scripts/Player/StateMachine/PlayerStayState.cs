using System;

public class PlayerStayState : PlayerBaseState
{
    private PlayerStateManager playerStateManager;

    public static Action EnterStayState;
    public static Action ExitStayState;

    public PlayerStayState(PlayerStateManager _playerStateManager)
    {
        playerStateManager = _playerStateManager;
    }
    public override void EnterState()
    {
        PlayerInputManager.MouseClicked += OnMouseClicked;
        EnterStayState?.Invoke();
    }
    public override void ExitState()
    {
        ExitStayState?.Invoke();
        PlayerInputManager.MouseClicked -= OnMouseClicked;
    }
    private void OnMouseClicked()
    {
        playerStateManager.SwitchState(playerStateManager.RunState);
    }
}
