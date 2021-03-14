using UnityEngine;

[CreateAssetMenu()]
public class TowerData : ScriptableObject
{
    public GameObject[] TowerGOs;
    public int purchaseCost;
    public int upgradeCostIncrement;
    public float fireRateIncrement;
    public float damageIncrement;
    public string towerName;
    public float initialFireRate;
    public float initialDamage;
    public float initialRange;
    public float rangeIncrement;
}