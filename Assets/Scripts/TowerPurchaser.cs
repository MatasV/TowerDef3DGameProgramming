using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerPurchaser : MonoBehaviour
{
    [SerializeField] private TowerData towerData;
    [SerializeField] private SharedInt playerMoney;

    //[SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button button;
    
    [SerializeField] private SharedBool isTowerPlacementControllerActive;
    [SerializeField] private GameObject placementController;
    
    private void OnValidate()
    {
        if (!(towerData is null))
        {
            //nameText.text = towerData.name;
            costText.text = $"$ {towerData.purchaseCost.ToString()}";
        }
    }

    private void Start()
    {
        if (!(towerData is null))
        {
            //nameText.text = towerData.name;
            costText.text = $"$ {towerData.purchaseCost.ToString()}";
        }

        CheckPlayerMoneyForTextColor();
        isTowerPlacementControllerActive.valueChangeEvent.AddListener(CheckForControllerActiveStatus);
    }
    
    private void CheckForControllerActiveStatus()
    {
        button.interactable = !isTowerPlacementControllerActive.Value;
    }
    
    private void CheckPlayerMoneyForTextColor()
    {
        if (!(playerMoney is null))
        {
            costText.color = playerMoney.Value >= towerData.purchaseCost ? Color.green : Color.red;
        }
    }

    public void Purchase()
    {
        if (playerMoney.Value >= towerData.purchaseCost)
        {
            var placementControllerClone =
                (TowerPlacementController) Instantiate(placementController)
                    .GetComponent(typeof(TowerPlacementController));
            placementControllerClone.Init(towerData);

            playerMoney.Value -= towerData.purchaseCost;
        }
    }

    private void OnDestroy()
    {
        isTowerPlacementControllerActive.valueChangeEvent.RemoveListener(CheckForControllerActiveStatus);
    }
}