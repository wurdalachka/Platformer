using TMPro;
using UnityEngine;

public class UI_coin_display : MonoBehaviour
{
    public coin_component coinComponent;
    public TextMeshProUGUI textComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        coinComponent.OnCoinChanged += OnCoinChanged;
        coinComponent.OnCoinIntialized += OnCoinIntialized;
    }

    private void OnCoinIntialized(float maxcoin)
    {
        textComponent.text = maxcoin.ToString();
    }

    private void OnCoinChanged(float newCoin, float amountChanged)
    {
        //Debug.Log(newHealth + ":" + amountChanged);
        textComponent.text = newCoin.ToString();
    }
}
