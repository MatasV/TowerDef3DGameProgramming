using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private GameObject indicatorGameObject;
    [SerializeField] private SharedBool isTowerPlacementActive;
    private void Start()
    {
        indicatorGameObject = transform.GetChild(0).gameObject;
        HideIndicator();
        isTowerPlacementActive.valueChangeEvent.AddListener(ShowIndicator);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1f);
    }

    private void OnDestroy()
    {
        isTowerPlacementActive.valueChangeEvent.RemoveListener(ShowIndicator);
    }

    public void HideIndicator()
    {
        indicatorGameObject.SetActive(false);
    }
    public void ShowIndicator()
    {
        if (isTowerPlacementActive)
        {
            if (tower is null) indicatorGameObject.SetActive(true);
        }
        else
        {
            indicatorGameObject.SetActive(false);
        }
    }

    public void PlaceTower(GameObject tower)
    {
        this.tower = tower.GetComponent<Tower>();
        this.tower.ready = true;
    }
}