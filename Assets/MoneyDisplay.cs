using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private SharedInt playerMoney;
    [SerializeField] private TMP_Text playerMoneyDisplay;
    private void Start()
    {
        playerMoney.valueChangeEvent.AddListener(DisplayMoney);
        DisplayMoney();
    }

    private void DisplayMoney()
    {
        playerMoneyDisplay.text = playerMoney.Value.ToString();
    }

    private void OnDestroy()
    {
        playerMoney.valueChangeEvent.RemoveListener(DisplayMoney);
    }
}
