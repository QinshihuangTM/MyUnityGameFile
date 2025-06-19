using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Character,
    Skill,
    //Support
}

public enum CharacterType
{
    战士,
    法师,
    坦克,
    辅助
}

[CreateAssetMenu(fileName ="NewCard",menuName ="Card/New Card")]
public class CardData : ScriptableObject
{
    public string cardID;
    public string cardName;
    public Sprite cardImage;

    public CardType cardType;
    public CharacterType characterType;

    public int health;
    public int attack;
    public int defense;

    public RarityData rarityData; //关联稀有度
    public SkillData skill; //关联技能

    [TextArea]
    public string description;
}
