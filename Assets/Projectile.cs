using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public virtual void Init(Transform enemyTransform, float damage)
    {
        transform.LookAt(enemyTransform);
        this.damage = damage;
    }
    protected virtual void Update()
    {
        transform.position += transform.forward * speed;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //Damage Enemy
            OnEnemyHit(other.gameObject);
        }
    }

    protected virtual void OnEnemyHit(GameObject other)
    {
        other.GetComponent<Enemy>().OnHit(damage);
    }
}