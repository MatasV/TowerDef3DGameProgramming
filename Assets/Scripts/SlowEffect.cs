using UnityEngine;
using UnityEngine.AI;

public class SlowEffect : StatusEffect
{
    public float slowTimes;

    private NavMeshAgent affectingEnemy;
    public override void ActivateStatus(Transform parent)
    {
        base.ActivateStatus(parent);
        if (affectee is null) return;
        affectingEnemy = affectee.GetComponent<NavMeshAgent>();
        affectingEnemy.speed /= slowTimes;
    }

    public override void DeactivateStatus()
    {
        if(affectingEnemy is null) return;
        affectingEnemy.speed *= slowTimes;
        base.DeactivateStatus();
    }
}