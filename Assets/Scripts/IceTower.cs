using UnityEngine;

public class IceTower : Tower
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float slowPercentage;
    [SerializeField] private float slowTime;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected override void Fire(Transform closestEnemy)
    {
        if (!ready) return;
        var proj = Instantiate(projectile, shootPoint.position, Quaternion.identity).GetComponent<IceProjectile>();
        proj.Init(closestEnemy, towerData.initialDamage + currentLevel * towerData.damageIncrement);
        proj.slowPercentage = slowPercentage;
        proj.slowTime = slowTime;
    }
}