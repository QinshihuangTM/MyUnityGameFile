using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleStarter : MonoBehaviour
{
    public CardData playerCard;
    public CardData enemyCard;

    public BattleManager battleManager;
    public Button startButton;

    public Button backButton_V;
    public Button backButton_D;


    public void OnStartBattle()
    {
        battleManager.StartBattle(playerCard, enemyCard);
        startButton.gameObject.SetActive(false);
    }

    public void backButton_V_OnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void backButton_D_OnClick()
    {
        SceneManager.LoadScene(1);
    }
}

