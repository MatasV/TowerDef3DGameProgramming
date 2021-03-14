using System;
using UnityEngine;

public class CrossbowTower : Tower
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected override void Fire(Transform closestEnemy)
    {
        if (!ready) return;
        Instantiate(projectile, shootPoint.position, Quaternion.identity).GetComponent<Projectile>().Init(closestEnemy, towerData.initialDamage + currentLevel * towerData.damageIncrement);
    }
}