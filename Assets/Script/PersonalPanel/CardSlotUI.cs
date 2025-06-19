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

    private CardData myData;

    public void Set(CardData data, int quantity)
    {
        myData = data;
        cardImage.sprite = data.cardImage;
        nameText.text = data.cardName;
        characterType.text = $"{data.characterType}";
        quantityText.text = $"×{quantity}";
        cardID.text = $"ID：{data.cardID}";

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
        CardDetailUIManager.Instance.ShowDetail(myData);
    }

}
