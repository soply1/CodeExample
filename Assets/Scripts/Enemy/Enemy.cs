using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyCharacter;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private EnemyData enemyData;
    private int curHealthPoints;
    public Collider EnemyCollider { get; private set; }

    public Action<Enemy> Died;

    private void Awake()
    {
        curHealthPoints = enemyData.HealthPoints;
        EnemyCollider = GetComponent<Collider>();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void TakeDamage(int _damage)
    {
        curHealthPoints -= _damage;
        progressBar.RefreshProgressBar(curHealthPoints, enemyData.HealthPoints);
        if (curHealthPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Died?.Invoke(this);
        progressBar.HideProgressBar();
        StartCoroutine(Dead());
    }
    private IEnumerator Dead()
    {
        EnemyCollider.enabled = false;
        enemyCharacter.SetActive(false);
        ragdoll.SetActive(true);
        yield return new WaitForSeconds(enemyData.TimeAfterDeath);
        Destroy(gameObject);
    }
}
