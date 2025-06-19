using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CoinTextBinder : MonoBehaviour
{
    void Start()
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.coinText = text;
            CoinManager.Instance.UpdateUI();
        }
    }
}
