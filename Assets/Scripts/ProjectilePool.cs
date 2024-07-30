using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Transform poolParent;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int pooledAmount;
    private List<Projectile> pooledProjectiles = new List<Projectile>();

    public static ProjectilePool Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            pooledProjectiles.Add(Instantiate(objectPrefab, shootPoint.position, Quaternion.identity, poolParent).GetComponent<Projectile>());
            pooledProjectiles[i].GetGameObject.SetActive(false);
        }
    }

    public Projectile GetPooledProjectile()
    {        foreach (Projectile projectile in pooledProjectiles)
        {
            if (!projectile.GetGameObject.activeInHierarchy)
            {
                projectile.GetGameObject.SetActive(true);
                projectile.GetTransform.position = shootPoint.position;
                return projectile;
            }
        }
        return CreatePooledProjectile();
    }
    private Projectile CreatePooledProjectile()
    {
        Projectile projectile = Instantiate(objectPrefab, shootPoint.position, Quaternion.identity, poolParent).GetComponent<Projectile>();
        pooledProjectiles.Add(projectile);
        projectile.GetGameObject.SetActive(true);
        return projectile;
    }
    public void ReturnPooledProjectile(Projectile _returnProjectile)
    {
        foreach (Projectile projectile in pooledProjectiles)
        {
            if (projectile == _returnProjectile)
            {
                projectile.GetGameObject.SetActive(false);
                projectile.GetTransform.position = shootPoint.position;
            }
        }
    }
}