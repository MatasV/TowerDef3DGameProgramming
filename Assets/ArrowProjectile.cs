using UnityEngine;

public class ArrowProjectile : Projectile
{
    private bool stopped = false;
    protected override void Update()
    {
        if (stopped) return;
        base.Update();
    }

    protected override void OnEnemyHit(GameObject other)
    {
        if(stopped) return;
        base.OnEnemyHit(other);
        transform.position += transform.forward * (Random.Range(0.2f, 0.4f));
        transform.SetParent(other.transform);
        stopped = true;
        
    }
}