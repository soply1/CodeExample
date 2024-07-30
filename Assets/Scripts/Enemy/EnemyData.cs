using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int healthPoints;
    [SerializeField] private int timeAfterDeath;
    public int HealthPoints { get { return healthPoints; } }
    public int TimeAfterDeath { get { return timeAfterDeath; } }
}
