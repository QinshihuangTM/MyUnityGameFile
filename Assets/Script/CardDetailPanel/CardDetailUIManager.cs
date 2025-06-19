using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDetailUIManager : MonoBehaviour
{
    public static CardDetailUIManager Instance;
    public CardDetailUI detailUI;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDetail(CardData data)
    {
        detailUI.ShowDetail(data);
    }

}
