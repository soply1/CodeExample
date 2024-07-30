using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Transform stageParent;
    private int nextStageIndex;
    private IStage nextStage;
    private List<IStage> stages = new List<IStage>();

    private void Awake()
    {
        foreach (IStage stage in stageParent.GetComponentsInChildren<IStage>())
        {
            stages.Add(stage);
        }
    }
    private void Start()
    {
        nextStage = stages[0];
        nextStage.TargetPoint.ActivateTarget();
    }
    private void OnEnable()
    {
        EnemyStage.StageReached += ChangeNextStage;
        FinishStage.StageReached += ChangeNextStage;
    }
    private void OnDisable()
    {
        EnemyStage.StageReached += ChangeNextStage;
        FinishStage.StageReached += ChangeNextStage;
    }

    private void ChangeNextStage()
    {
        if (nextStageIndex + 1 >= stages.Count)
        {
            return;
        }
        nextStage = stages[nextStageIndex + 1];
        nextStageIndex++;
        nextStage.TargetPoint.ActivateTarget();
    }
    public Vector3 GetNextTargetPosition()
    {
        return nextStage.TargetPoint.GetPosition();
    }
}
