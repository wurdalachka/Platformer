using System.Collections;
using UnityEngine;

public class healthcomponent : MonoBehaviour
{
    private float health = 10;

    public float maxHealth = 10;
    private bool invicibility;

    public delegate void OnHealthIntializedHandler(float newHealth);
    public delegate void OnHealthChangeHandler(float newHealth, float amountChanged);
    public event OnHealthIntializedHandler OnHealthIntialized;
    public event OnHealthChangeHandler OnHealthChanged;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        OnHealthIntialized?.Invoke(health);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddDamage(float damage)
    {
        if (!invicibility)
        {
            health -= damage;
            OnHealthIntialized?.Invoke(health);
            invicibility = true;
            StartCoroutine(ResetInvincibility(3));
        }



            if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        OnHealthIntialized?.Invoke(health);
    }
    IEnumerator ResetInvincibility(float resetTime)
        {
            yield return new WaitForSeconds(resetTime);
            Debug.Log("Reset");
        }



public void AddHealth(float healingValue)
    {
        health += healingValue;
        OnHealthChanged?.Invoke(maxHealth, health);

        if (health >= maxHealth)
        {
            health = maxHealth;
            
        }


        //Debug.Log(health);
    }
}
