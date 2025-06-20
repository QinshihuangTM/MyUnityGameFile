using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSlotUI : MonoBehaviour
{
    public Image cardImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI cardID;
    public TextMeshProUGUI characterType;
    public TextMeshProUGUI cardLevel;

    private OwnedCard ownedCard;

    public void Set(OwnedCard card)
    {
        ownedCard = card;
        CardData data = card.cardData;

        cardImage.sprite = data.cardImage;
        nameText.text = data.cardName;
        characterType.text = $"{data.characterType}";
        quantityText.text = $"×{card.quantity}";

        if(data.cardID != null)
        {
            cardID.text = $"ID：{data.cardID}";
        }
        else
        {
            cardID.text = "ID 未知";
        }


        if (data.rarityData != null)
        {
            cardLevel.text = data.rarityData.rarityType.ToString();
            cardLevel.color = data.rarityData.cardColor;
        }
        else
        {
            cardLevel.text = "N";
            cardLevel.color = Color.gray;
        }
    }

    public void OnClickShowDetail()
    {
        CardDetailUIManager.Instance.ShowDetail(ownedCard);
    }

}
