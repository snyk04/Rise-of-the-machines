﻿using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform muzzleHole;
    [SerializeField] private LayerMask damageableLayer;

    private void OnDrawGizmos()
    {
        Debug.DrawRay(muzzleHole.position, muzzleHole.forward * 25);
    }

    public void Shoot()
    {
        var shootingRay = new Ray(muzzleHole.position, muzzleHole.forward);
        if (Physics.Raycast(shootingRay, out RaycastHit hitInfo, 25))
        {
            if (hitInfo.transform.TryGetComponent(out Damageable damageable))
            {
                damageable.TakeDamage(15);
            }
        }
    }
}
