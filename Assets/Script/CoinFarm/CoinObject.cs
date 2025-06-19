using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinObject : MonoBehaviour
{
    public Button coin_button;

    void Start()
    {
        coin_button = GetComponent<Button>();
        coin_button.onClick.AddListener(OnCoinClick);
    }

    public void OnCoinClick()
    {
        CoinManager.Instance.AddCoins(100);
        Destroy(gameObject);
    }
}
