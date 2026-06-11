using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damage = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthcomponent health = collision.GetComponent<healthcomponent>();
        if (health != null)
        {
            health.AddDamage(damage);
        }
    }
}
