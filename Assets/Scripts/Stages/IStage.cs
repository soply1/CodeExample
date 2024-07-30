using System;

public interface IStage
{
    public static Action StageReached;
    public TargetPoint TargetPoint { get; }
}
