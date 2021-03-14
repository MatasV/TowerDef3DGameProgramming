using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementUIEnabler : MonoBehaviour
{

    public SharedBool isTowerPlacerActive;
    void Start()
    {
        isTowerPlacerActive.valueChangeEvent.AddListener(DisableEnableUI);
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void DisableEnableUI()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isTowerPlacerActive);
        }
    }

    private void OnDestroy()
    {
        isTowerPlacerActive.valueChangeEvent.RemoveListener(DisableEnableUI);
    }
}
