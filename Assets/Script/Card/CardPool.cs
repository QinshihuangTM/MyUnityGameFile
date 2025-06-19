using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CardPool",menuName ="Card/Card Pool")]
public class CardPool : ScriptableObject
{
    public List<CardData> allCards;
}
