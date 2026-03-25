using UnityEngine;

public class spike : MonoBehaviour
{
    public float Damage = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        collision.GetComponent<healthcomponent>().AddDamage(Damage);
    }
}
