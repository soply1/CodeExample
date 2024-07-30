using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerShootState.EnterShootState += OnEnterShootState;
        PlayerShootState.ExitShootState += OnExitShootState;
    }
    private void OnDisable()
    {
        PlayerShootState.EnterShootState -= OnEnterShootState;
        PlayerShootState.ExitShootState -= OnExitShootState;
    }
    private void OnEnterShootState()
    {
        PlayerInputManager.MouseClicked += Shoot;
    }
    private void OnExitShootState()
    {
        PlayerInputManager.MouseClicked -= Shoot;
    }
    private void Shoot()
    {
        Projectile projectile = ProjectilePool.Instance.GetPooledProjectile();
        projectile.Fire(PlayerInputManager.GetWorldMousePosition() - projectile.GetTransform.position);
    }
}
