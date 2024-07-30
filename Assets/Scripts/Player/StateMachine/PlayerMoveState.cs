using System;

public class PlayerMoveState : PlayerBaseState
{
    private PlayerStateManager playerStateManager;

    public static Action EnterMoveState;
    public static Action ExitMoveState;

    public PlayerMoveState(PlayerStateManager _playerStateManager)
    {
        playerStateManager = _playerStateManager;
    }
    public override void EnterState()
    {
        EnemyStage.StageReached += OnEnemyStageReached;
        FinishStage.StageReached += OnFinishStageReached;
        EnterMoveState?.Invoke();
    }
    public override void ExitState()
    {
        ExitMoveState?.Invoke();
        EnemyStage.StageReached -= OnEnemyStageReached;
        FinishStage.StageReached -= OnFinishStageReached;
    }
    private void OnEnemyStageReached()
    {
        playerStateManager.SwitchState(playerStateManager.EnemyState);
    }
    private void OnFinishStageReached()
    {
        playerStateManager.SwitchState(playerStateManager.StayState);
    }
}
