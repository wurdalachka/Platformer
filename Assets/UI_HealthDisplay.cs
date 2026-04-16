using System;
using UnityEngine;

public class UI_HealthDisplay : MonoBehaviour
{
    public healthcomponent healthComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthComponent.OnHealthChanged += OnHealthChanged;
        
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
       Debug.Log(newHealth + ":" + amountChanged);
    }
}
