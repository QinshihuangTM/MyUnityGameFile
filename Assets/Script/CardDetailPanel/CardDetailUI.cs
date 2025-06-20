using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDetailUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idText;
    public Image cardImage;
    public TextMeshProUGUI statsText;
    public Button sellButton;

    public TextMeshProUGUI rarityText;
    public TextMeshProUGUI haveAmountText;

    public GameObject detailPanel;
    public GameObject backpackPanel;
    public GameObject mainPanel;

    private OwnedCard currentCard;

    public void ShowDetail(OwnedCard card)
    {
        if (card == null)
        {
            Debug.LogError("传入的 card 是 null！");
            return;
        }

        currentCard = card;

        detailPanel.SetActive(true);
        backpackPanel.SetActive(false);
        mainPanel.SetActive(false);

        var data = card.cardData;

        haveAmountText.text = $"拥有：{card.quantity} 张";

        nameText.text = data.cardName;
        idText.text = data.cardID;
        cardImage.sprite = data.cardImage;
        statsText.text = $"职业：{data.characterType} \n" +
            $"生命值: {data.health} \n" +
                  $"攻击力: {data.attack} \n" +
                  $"防御值: {data.defense} \n";

        if (data.skill != null)
        {
            statsText.text += $"技能：{data.skill.skillName}\n({data.skill.description})";
        }
        else
        {
            statsText.text += "技能：无";
        }

        if (data.cardID != null)
        {
            idText.text = $"ID {data.cardID}";
        }
        else
        {
            idText.text = "ID 未知";
        }

        if (data.rarityData != null)
        {

            rarityText.text = data.rarityData.rarityType.ToString();
            rarityText.color = data.rarityData.cardColor;
        }

        sellButton.gameObject.SetActive(card.quantity > 1);

    }

    public void Close()
    {
        detailPanel.SetActive(false);
        backpackPanel.SetActive(true);
        mainPanel.SetActive(true);
    }

    public void OnClickSellButton()
    {
        if (currentCard != null && currentCard.quantity > 1)
        {
            currentCard.quantity--;

            int sellPrice = 50;

            if(currentCard.cardData.rarityData != null)
            {
                sellPrice = currentCard.cardData.rarityData.sellPrice;
            }

            CoinManager.Instance.AddCoins(sellPrice);

            CoinManager.Instance.UpdateUI();

            BackpackManager.Instance.SaveData();
            ShowDetail(currentCard); // 刷新显示
            BackpackUIManager.Instance.RefreshUI(); // 刷新背包UI

        }
    }

}
