using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishStage : MonoBehaviour, IStage
{
    [SerializeField] private WayPoint wayPoint;

    private void OnEnable()
    {
        wayPoint.Reached += OnWayPointReached;
    }
    private void OnDisable()
    {
        wayPoint.Reached -= OnWayPointReached;
    }
    private void OnWayPointReached()
    {
        SceneManager.LoadScene(0);
        IStage.StageReached?.Invoke(this);
    }
    public Vector3 GetPosition()
    {
        return wayPoint.transform.position;
    }
}