using System;

public class PlayerShootState : PlayerBaseState
{
    private PlayerStateManager playerStateManager;

    public static Action EnterShootState;
    public static Action ExitShootState;

    public PlayerShootState(PlayerStateManager _playerStateManager)
    {
        playerStateManager = _playerStateManager;
    }
    public override void EnterState()
    {
        EnemyStage.StageCompleted += OnAllEnemiesDead;
        EnterShootState?.Invoke();
    }
    public override void ExitState()
    {
        ExitShootState?.Invoke();
        EnemyStage.StageCompleted -= OnAllEnemiesDead;
    }
    private void OnAllEnemiesDead()
    {
        playerStateManager.SwitchState(playerStateManager.RunState);
    }
}