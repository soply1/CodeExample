using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class TargetPoint : MonoBehaviour
{
    public Action TargetPointReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TargetPointReached?.Invoke();
            gameObject.SetActive(false);
        }
    }
    public void ActivateTarget()
    {
        gameObject.SetActive(true);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}