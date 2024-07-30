using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private Transform enemiesParent;
    private List<Enemy> aliveEnemies = new List<Enemy>();

    public Action AllEnemiesDead;

    private void Start()
    {
        for (int i = 0; i < enemiesParent.childCount; i++)
        {
            if (enemiesParent.GetChild(i).TryGetComponent(out Enemy enemy))
            {
                aliveEnemies.Add(enemy);
                enemy.Died += RemoveDeadEnemy;
                if (enemy.EnemyCollider.enabled)
                {
                    enemy.EnemyCollider.enabled = false;
                }
            }
        }
    }

    private void RemoveDeadEnemy(Enemy _enemy)
    {
        aliveEnemies.Remove(_enemy);
        if (aliveEnemies.Count == 0)
        {
            AllEnemiesDead?.Invoke();
        }
    }
    public void ActivateEnemiesColliders()
    {
        foreach (Enemy enemy in aliveEnemies)
        {
            enemy.EnemyCollider.enabled = true;
        }
    }
}
