
/// <summary>
/// Parent for all states.
/// </summary>
public abstract class PlayerBaseState
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}