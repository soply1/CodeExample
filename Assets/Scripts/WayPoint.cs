using System;
using UnityEngine;

/// <summary>
/// Simple collision and nothing more
/// </summary>
public class WayPoint : MonoBehaviour
{
    public Action Reached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Reached?.Invoke();
            gameObject.SetActive(false);
        }
    }
}