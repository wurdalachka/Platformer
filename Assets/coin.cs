using UnityEngine;

public class coin : MonoBehaviour
    
    
{
    public float coinValue = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<coin_component>().AddCoin(coinValue);
        Destroy(gameObject);
    }
}
