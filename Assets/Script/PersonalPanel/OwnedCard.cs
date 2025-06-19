using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OwnedCard
{
    public CardData cardData;
    public int quantity;

    //获得卡片时，Owned一下：
    public OwnedCard(CardData data,int count = 1)
    {
        cardData = data;
        quantity = count;
    }
}
