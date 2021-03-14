using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private SharedInt health;
    [SerializeField] private TMP_Text healthText;
    

    private void Start()
    {
        health.valueChangeEvent.AddListener(DisplayHealth);
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.text = health.Value.ToString();
    }

    private void OnDisable()
    {
        health.valueChangeEvent.RemoveListener(DisplayHealth);
    }
}
