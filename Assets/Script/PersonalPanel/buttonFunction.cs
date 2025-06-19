using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    public Button goback_Main_Button;
    public Button goback_Backpack_Button;
    public Button storeButton;
    public Button CoinFarmButton;
    public Button BossBattleButton;

    public GameObject backpackPanel;
    public GameObject PersonalPanel;

    void Start()
    {
        goback_Main_Button.onClick.AddListener(goback_Main_ButtonOnClick);
        goback_Backpack_Button.onClick.AddListener (goback_Backpack_ButtonOnClick);
        storeButton.onClick.AddListener(storeButtonOnClick);
        CoinFarmButton.onClick.AddListener(goToCoinFarmScene);
        BossBattleButton.onClick.AddListener(BossBattle);
    }

    public void goToCoinFarmScene()
    {
        SceneManager.LoadScene(3);
    }

    public void storeButtonOnClick()
    {
        SceneManager.LoadScene(2);
    }

    public void goback_Backpack_ButtonOnClick()
    {
        backpackPanel.SetActive(false);
        PersonalPanel.SetActive(true);
    }

    public void goback_Main_ButtonOnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void BossBattle()
    {
        SceneManager.LoadScene(4);
    }
}
