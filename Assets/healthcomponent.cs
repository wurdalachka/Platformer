using System.Collections;
using UnityEngine;

public class healthcomponent : MonoBehaviour
{
    private float health = 10;

    public float maxHealth = 10;
    private bool invicibility;

    public delegate void OnHealthIntializedHandler(float newHealth);
    public delegate void OnHealthChangeHandler(float newHealth, float amountChanged);
    public event OnHealthChangeHandler OnHealthChanged;
    public event OnHealthIntializedHandler OnHealthIntialized;
   



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
            OnHealthChanged?.Invoke(health, damage);
            invicibility = true;
            StartCoroutine(ResetInvincibility(1));
        }



            if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        OnHealthChanged?.Invoke(health, - damage);
    }
    IEnumerator ResetInvincibility(float resetTime)
        {
            yield return new WaitForSeconds(resetTime);
            invicibility = false;
        }



public void AddHealth(float healingValue)
    {
        health += healingValue;
     

        if (health >= maxHealth)
        {
            health = maxHealth;
            
        }
        OnHealthChanged?.Invoke(maxHealth, health);

        //Debug.Log(health);
    }
}
