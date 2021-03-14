using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private SharedInt health;
    [SerializeField] private StagePlayerData stagePlayerData;

    public SharedBool playerLost;
    private void Awake()
    {
        health.Value = stagePlayerData.health;
        playerLost.Value = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            health.Value--;
            Destroy(other.gameObject);

            if (health.Value <= 0)
            {
                playerLost.Value = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            health.Value--;
            Destroy(other.gameObject);

            if (health.Value <= 0)
            {
                playerLost.Value = true;
            }
        }
    }
}