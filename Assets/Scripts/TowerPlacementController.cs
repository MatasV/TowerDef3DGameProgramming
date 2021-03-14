using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    [SerializeField] private SharedBool isPlacementControllerActive;
    [SerializeField] private SharedInt playerMoney;
    private GameObject currentGameObject;
    private TowerData currentTowerData;
    
    private LayerMask layerMask = new LayerMask();
    private Camera cam;
    public void Init(TowerData towerData)
    {
        currentTowerData = towerData;
        layerMask = LayerMask.GetMask("TowerPlacement", "Terrain");
        currentGameObject = Instantiate(towerData.TowerGOs[0], Input.mousePosition, Quaternion.identity);
        cam = Camera.main;
    }

    private void OnEnable()
    {
        isPlacementControllerActive.Value = true;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] results = new RaycastHit[100];
        int n = Physics.RaycastNonAlloc(ray, results, 100f, layerMask);

        GameObject nearestPlacementSpot = null;
        float closestPlacementSpotDistance = 100000;

        Vector3? nearestTerrainSpot = null;
        
        for (int i = 0; i < n; i++)
        {
            if (results[i].collider.gameObject.layer == 6)
            {
                if (closestPlacementSpotDistance > results[i].distance)
                {
                    nearestPlacementSpot = results[i].collider.gameObject;
                    closestPlacementSpotDistance = results[i].distance;
                }
            }
            else if (results[i].collider.gameObject.layer == 7)
            {
                nearestTerrainSpot = results[i].point;
            }
        }

        if (nearestPlacementSpot is null)
        {
            if (!(nearestTerrainSpot is null))
            {
                currentGameObject.transform.position = nearestTerrainSpot.Value;
            }
        }
        else
        {
            currentGameObject.transform.position = nearestPlacementSpot.transform.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!(nearestPlacementSpot is null))
            {
                var towerSpot = nearestPlacementSpot.GetComponent<TowerSpot>();
                towerSpot.PlaceTower(currentGameObject);
                Destroy(gameObject);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            playerMoney.Value += currentTowerData.purchaseCost;
            Destroy(currentGameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        isPlacementControllerActive.Value = false;
    }
}