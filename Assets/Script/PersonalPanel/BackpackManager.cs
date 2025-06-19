using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BackpackManager : MonoBehaviour
{
    public static BackpackManager Instance;
    public List<OwnedCard> ownedCards = new List<OwnedCard>();

    private string savePath;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/backpack.json";
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCard(CardData card)
    {
        foreach(var owned in ownedCards)
        {
            if(owned.cardData.cardID == card.cardID)
            {
                owned.quantity++;
                //Debug.Log($"已拥有卡：{card.cardName}，数量+1 → {owned.quantity}");
                SaveData();
                return;
            }
        }
        ownedCards.Add(new OwnedCard(card));
        //Debug.Log($"新增卡牌：{card.cardName} 添加到背包");
        SaveData();
    }

    public void SaveData()
    {
        List<SerializableCard> saveList = new List<SerializableCard>();
        foreach (var owned in ownedCards)
        {
            saveList.Add(new SerializableCard { cardID = owned.cardData.cardID, quantity = owned.quantity });
        }

        string json = JsonUtility.ToJson(new SaveDataWrapper { cards = saveList }, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadData()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("首次运行，未找到存档，创建新文件");
            SaveData(); // 创建空文件
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveDataWrapper wrapper = JsonUtility.FromJson<SaveDataWrapper>(json);

        ownedCards.Clear();
        foreach (var item in wrapper.cards)
        {
            CardData found = Resources.Load<CardData>($"Cards/{item.cardID}");
            if (found != null)
            {
                ownedCards.Add(new OwnedCard(found, item.quantity));
            }
        }
    }
    [System.Serializable]
    public class SerializableCard
    {
        public string cardID;
        public int quantity;
    }

    [System.Serializable]
    public class SaveDataWrapper
    {
        public List<SerializableCard> cards;
    }
}
