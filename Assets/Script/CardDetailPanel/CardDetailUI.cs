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
    //public Image borderImage;

    public TextMeshProUGUI rarityText;

    public GameObject detailPanel;
    public GameObject backpackPanel;
    public GameObject mainPanel;

    public void ShowDetail(CardData data)
    {
        if (data == null)
        {
            Debug.LogError("传入的 card 是 null！");
            return;
        }

        detailPanel.SetActive(true);
        backpackPanel.SetActive(false);
        mainPanel.SetActive(false);


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
    }

    public void Close()
    {
        detailPanel.SetActive(false);
        backpackPanel.SetActive(true);
        mainPanel.SetActive(true);
    }
}
