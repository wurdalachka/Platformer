using UnityEngine;

public class coin_component : MonoBehaviour
{
    
    public float maxcoin = 0;

    public delegate void OnCoinIntializedHandler(float maxcoin);
    public delegate void OnCoinChangeHandler(float newCoin, float amountChanged);
    public event OnCoinIntializedHandler OnCoinIntialized;
    public event OnCoinChangeHandler OnCoinChanged;
    public coin_component coinComponent;
    public float heal = 10;
    

    void Start()
    {
    
        OnCoinIntialized?.Invoke(maxcoin);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        
    }

    // Update is called once per frame
    public void AddCoin(float coinValue)
    {
        maxcoin += coinValue;
        OnCoinChanged?.Invoke(maxcoin, coinValue);

        
       if (maxcoin >= 10)
        {
              maxcoin = maxcoin -10;
              GetComponent<healthcomponent>().AddHealth(heal);

        }
        

    }


}