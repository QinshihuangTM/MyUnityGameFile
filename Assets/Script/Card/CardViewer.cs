using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardViewer : MonoBehaviour
{
    public CardData card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idText;
    public Image cardImage;
    public TextMeshProUGUI statsText;
    //public Image borderImage;

    public TextMeshProUGUI rarityText;

    public void SetCard(CardData card)
    {
        nameText.text = card.cardName;
        idText.text = card.cardID;
        cardImage.sprite = card.cardImage;
        statsText.text = $"职业：{card.characterType} \n" +
            $"生命值: {card.health} \n"+
                  $"攻击力: {card.attack} \n" +
                  $"防御值: {card.defense} \n";

        if (card.skill != null)
        {
            statsText.text += $"技能：{card.skill.skillName}\n({card.skill.description})";
        }
        else
        {
            statsText.text += "技能：无";
        }

        if (card.cardID != null)
        {
            idText.text = $"ID {card.cardID}";
        }
        else
        {
            idText.text = "ID 未知";
        }

        //borderImage.color = card.rarityData.cardColor;

        if (card.rarityData != null)
        {
            //borderImage.color = card.rarityData.cardColor;

            rarityText.text = card.rarityData.rarityType.ToString();
            rarityText.color = card.rarityData.cardColor; 
        }

    }
}
