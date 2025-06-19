using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idText;
    public Image cardImage;
    public TextMeshProUGUI statsText;

    public TextMeshProUGUI rarityText;


    public GameObject cardBack;
    public GameObject cardFront;

    //public float flipDuration = 0.2f;

    private bool isFront = false;

    private void Start()
    {
        // 初始状态
        //transform.localScale = new Vector3(1, 1, 1); // 正常显示卡背
        //transform.localScale = Vector3.one;
        //cardBack.SetActive(true);
        //cardFront.SetActive(false);
    }

    public void FlipToFront()
    {
        if (isFront) return;
        isFront = true;

        transform.DOScaleX(0, 0.75f)
            .OnComplete(() =>
            {
                cardBack.SetActive(false);
                cardFront.SetActive(true);
                transform.DOScaleX(1, 0.75f).SetEase(Ease.OutBack);
            });
    }

    public void SetCard(CardData card)
    {
        nameText.text = card.cardName;
        idText.text = card.cardID;
        cardImage.sprite = card.cardImage;
        statsText.text = $"职业：{card.characterType} \n" +
            $"生命值: {card.health} \n" +
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

        // 初始化状态：正面隐藏，背面显示
        //cardFront.SetActive(false);
        //cardBack.SetActive(true);

        //// 重置旋转角度
        //transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

}
