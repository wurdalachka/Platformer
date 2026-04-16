using UnityEngine;

public class healthcomponent : MonoBehaviour
{
    private float health = 10;

    public float maxHealth = 10;


    public delegate void OnHealthChangeHandler(float newHealth, float amountChanged);
    public event OnHealthChangeHandler OnHealthChanged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddDamage(float damage)
    {
        health -= damage;
        //Debug.Log(health);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
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
