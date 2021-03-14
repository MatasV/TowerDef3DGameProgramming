using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public bool ready = false;
    public TowerData towerData;
    public int currentLevel = 0;
    public float range;
    private float rateOfFire;
    public void Init(){Debug.Log($"{this.name} Initiated");}
    public Transform turret;

    private float shootTimer = 0f;

    private void OnEnable()
    {
        rateOfFire = towerData.initialFireRate + currentLevel * towerData.fireRateIncrement;
        range = towerData.initialRange + currentLevel * towerData.rangeIncrement;
    }
    
    protected virtual void Update()
    {
        RaycastHit[] results = new RaycastHit[100];
        Ray ray = new Ray(transform.position, Vector3.zero);
        
        int n = Physics.SphereCastNonAlloc(transform.position, range, Vector3.down, results, 1, LayerMask.GetMask("Enemy"));

        GameObject closestEnemy = null;
        float closestEnemyDistance = 1000f;
        
        for (int i = 0; i < n; i++)
        {
            if (results[i].distance < closestEnemyDistance)
            {
                closestEnemy = results[i].collider.gameObject;
                closestEnemyDistance = results[i].distance;
            }
        }

        if (closestEnemy != null)
        {
            turret.LookAt(closestEnemy.transform);
        }

        shootTimer += Time.deltaTime;
        if (shootTimer >= 1/rateOfFire && closestEnemy!=null)
        {
            shootTimer = 0;
            Fire(closestEnemy.transform);
        }
    }

    protected virtual void Fire(Transform closestEnemy)
    {
        Debug.Log($"{name} Fired!");
    }
}