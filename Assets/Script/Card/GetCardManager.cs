using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetCardManager : MonoBehaviour
{
    public CardPool cardPool;
    public Transform cardDisplay;
    public GameObject cardUIPrefab;
    public GameObject cardFlipPrefab;

    public GameObject showGetCardPanel;
    public GameObject StorePanel;
    public GameObject StartPanel;

    public GameObject GetCardButton;
    public GameObject backButton;
    public GameObject getCoinButton;
    public GameObject closeButton;
    public GameObject BacktoMenuButton;

    private void Start()
    {
        showGetCardPanel.SetActive(false);
        closeButton.SetActive(false);
    }

    public void OnClickGetButton()
    {
        if (CoinManager.Instance.currentCoins < 100)
        {
            HintUIManager.Instance.ShowHint("金币不足");
        }
        else
        {
            //消耗100金币：
            CoinManager.Instance.SpendCoins(100);

            showGetCardPanel.SetActive(true);
            GetCardButton.SetActive(false);
            backButton.SetActive(false);
            closeButton.SetActive(true);

            DrawThreeCards();
        }
    }

    public void OnClickBackButton()
    {
        StorePanel.SetActive(false);
        StartPanel.SetActive(true);
    }


    public void OnClickCloseButton()
    {
        showGetCardPanel.SetActive(true);
        GetCardButton.SetActive(true);
        backButton.SetActive(true);
        closeButton.SetActive(false);

        foreach (Transform child in cardDisplay)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnClickBacktoMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickgetCoinButton()
    {
        //beta2:
        //CoinManager.Instance.AddCoins(100);
        //beta3:
        SceneManager.LoadScene(3);
    }

    public void DrawThreeCards()
    {
        foreach(Transform child in cardDisplay)
        {
            Destroy(child.gameObject);//清空旧卡
        }

        List<CardData> result = DrawCards(1);

        foreach (CardData card in result)
        {
            //Debug.Log("抽到卡牌：" + card.cardName + "，ID：" + card.cardID);
            BackpackManager.Instance.AddCard(card);

            GameObject go = Instantiate(cardFlipPrefab, cardDisplay);
            //go.GetComponent<CardViewer>().SetCard(card);
            CardFlip flip = go.GetComponent<CardFlip>();
            flip.SetCard(card);
            flip.FlipToFront();
        }
        
    }

    private List<CardData> DrawCards(int count)
    {
        List<CardData> result = new List<CardData>();
        List<CardData> pool = cardPool.allCards;

        for (int i = 0; i < count; i++) 
        {
            CardData selectedCard = GetRandomCardByWeight(pool);
            result.Add(selectedCard);
        }
        return result;
    }

    private CardData GetRandomCardByWeight (List<CardData> pool)
    {
        //计算总权重(所有卡牌稀有度的总和)
        float totalWeight = 0f;

        foreach(var card in pool)
        {
            if(card.rarityData != null)
            {
                totalWeight += card.rarityData.dropRate;
            }
        }

        float rand = Random.Range(0f, totalWeight);
        float current = 0f;

        foreach(var card in pool)
        {
            if (card.rarityData == null) continue;

            current += card.rarityData.dropRate;

            if (rand <= current)
                return card;
        }

        return pool[Random.Range(0, pool.Count)];
    }
}
