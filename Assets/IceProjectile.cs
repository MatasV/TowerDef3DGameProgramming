using UnityEngine;

public class IceProjectile : Projectile
{
    public float slowPercentage;
    public float slowTime;
    public GameObject statusEffect;
    protected override void OnEnemyHit(GameObject other)
    {
        base.OnEnemyHit(other);
        var status = Instantiate(statusEffect).GetComponent<SlowEffect>();
        status.slowTimes = slowPercentage;
        status.effectTimer = slowTime;
        status.ActivateStatus(other.transform);
        Destroy(gameObject);
    }
}