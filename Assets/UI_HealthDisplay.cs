using System;
using UnityEngine;
using TMPro;

public class UI_HealthDisplay : MonoBehaviour
{
    public healthcomponent healthComponent;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthComponent.OnHealthChanged += OnHealthChanged;
        healthComponent.OnHealthIntialized += OnHealthIntialized;
     
    }

    private void OnHealthIntialized(float newHealth)
    {
       textComponent.text = newHealth.ToString();
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log(newHealth + ":" + amountChanged);
        textComponent.text = newHealth.ToString();
    }
}
