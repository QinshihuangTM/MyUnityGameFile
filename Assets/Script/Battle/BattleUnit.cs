using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    public CardData cardData;
    public int currentHP;

    public Image cardImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI statsText;

    public void UpdateUI()
    {
        hpText.text = $"HP:{currentHP}";
        nameText.text = cardData.cardName;
        cardImage.sprite = cardData.cardImage;

        statsText.text = $"攻击力 {cardData.attack} \n"
            + $"防御力 {cardData.defense} \n";

        if(cardData.skill != null)
        {
            statsText.text += $"技能 {cardData.skill.skillName}({cardData.skill.description})";
        }
        else
        {
            statsText.text += "技能 无";
        }
    }

    //初始化：
    public void Init(CardData data)
    {
        cardData = data;
        currentHP = data.health;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Max(0, currentHP);
        UpdateUI();
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Min(currentHP,cardData.health);
        UpdateUI();
    }

    public bool IsDead()
    {
        return currentHP <= 0;
    }

}
