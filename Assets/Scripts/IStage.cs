using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStage
{
    public Vector3 GetPosition();
    public static Action<IStage> StageReached;
}
