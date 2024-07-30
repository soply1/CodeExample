using System;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private static Camera mainCamera;

    public static Action MouseClicked;

    private void OnEnable()
    {
        mainCamera = Camera.main;
    }
    private void OnDisable()
    {
        mainCamera = null;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }
    }

    public static Vector3 GetWorldMousePosition()
    {
        RaycastHit hit;
        
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f))
        {
            return hit.point;
        }
        return ray.direction * 50f;
    }
}