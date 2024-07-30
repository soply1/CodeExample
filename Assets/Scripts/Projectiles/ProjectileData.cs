using UnityEngine;

[CreateAssetMenu(fileName = "New ProjectileData", menuName = "ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    public float MoveSpeed { get { return moveSpeed; } }
    public int Damage { get { return damage; } }
}
