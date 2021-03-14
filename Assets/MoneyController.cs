using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public bool debug;

    [SerializeField] private SharedInt money;
    [SerializeField] private StagePlayerData stagePlayerData;
    
    [ContextMenu("Add1000Money")]
    public void Add1000Money()
    {
        money.Value += 1000;
    }

    private void Awake()
    {
        if (!debug)
        {
            money.Value = stagePlayerData.startingMoney;
        }
    }
}
