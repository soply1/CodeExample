using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileData projectileData;
    private Vector3 fireDirection;
    private bool isFiring;

    private void Update()
    {
        if (isFiring)
        {
            transform.position += fireDirection.normalized * projectileData.MoveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(projectileData.Damage);
        }
        isFiring = false;
        ProjectilePool.Instance.ReturnPooledProjectile(this);
    }

    public void Fire(Vector3 direction)
    {
        fireDirection = direction;
        isFiring = true;
    }
    public GameObject GetGameObject { get { return gameObject; } }
    public Transform GetTransform { get { return transform; } }
}
