using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int currentCoins = 0;
    public TextMeshProUGUI coinText;

    private const string SAVE_KEY = "PlayerCoins";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadCoins();
    }

    void Start()
    {
        UpdateUI();
    }

    public void LoadCoins()
    {
        currentCoins = PlayerPrefs.GetInt(SAVE_KEY, 0);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        SaveCoins();
        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if(currentCoins >= amount)
        {
            currentCoins -= amount;
            SaveCoins();
            UpdateUI();
            return true;
        }
        else 
        {
            Debug.Log("");
            return false;
        }
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(SAVE_KEY, currentCoins);
        PlayerPrefs.Save();
    }

    public void UpdateUI()
    {
        if(coinText != null)
        {
            coinText.text = "金币:" + currentCoins;
        }
    }
}
