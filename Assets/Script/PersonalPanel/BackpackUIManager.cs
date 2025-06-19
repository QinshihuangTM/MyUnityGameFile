using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUIManager : MonoBehaviour
{
    public GameObject backpackPanel; // 指向 MyCardBp
    public GameObject cardSlotPrefab;
    public Transform contentParent;

    public void ToggleBackpack()
    {
        bool active = !backpackPanel.activeSelf;
        backpackPanel.SetActive(active);

        if (active)
        {
            //Debug.Log("打开背包，刷新内容");
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        //Debug.Log("刷新背包 UI 中...");

        // 检查是否有卡牌数据
        int count = BackpackManager.Instance.ownedCards.Count;
        //Debug.Log("当前背包卡牌数量：" + count);

        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var card in BackpackManager.Instance.ownedCards)
        {
            //Debug.Log("展示卡牌：" + card.cardData.cardName);
            GameObject go = Instantiate(cardSlotPrefab, contentParent);
            go.GetComponent<CardSlotUI>().Set(card.cardData, card.quantity);
        }
    }

}
