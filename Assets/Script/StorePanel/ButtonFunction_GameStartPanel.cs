using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction_GameStartPanel : MonoBehaviour
{
    public Button button_Up;
    public Button button_Down;

    public GameObject StorePanel;

    void Update()
    {

    }

    public void ShowStoreInterface()
    {
        gameObject.SetActive(false);
        StorePanel.SetActive(true);
    }

    public void ShowGetCoinInterface()
    {

    }

}
