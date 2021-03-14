using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Slider healthDisplayImage;
   public float health;
   public enum Type {Ground, Air}
   public Type type;
   public int moneyGained;
   
   public EnemyWaveSpawner enemyWaveSpawner;
   public SharedInt playerMoney;
   
   public Transform statusTransform;
   protected virtual void OnEnable()
   {
      healthDisplayImage.maxValue = health;
      healthDisplayImage.value = health;
   }

   public virtual void OnHit(float damage)
   {
      health -= damage;
      healthDisplayImage.value = health;

      if (health <= 0)
      {
         playerMoney.Value += moneyGained;
         Destroy(gameObject);
      }
   }

   private void OnDestroy()
   {
      enemyWaveSpawner.EnemyDead();
   }
}
