using System;
using UnityEngine;

/// <summary>
/// On state enter StayState subscribe at Left Mouse Button Click and switch state when Mouse is been clicked.
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    public static Action MouseClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }
    }
}