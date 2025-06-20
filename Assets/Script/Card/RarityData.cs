using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RarityType
{
    C,
    B,
    A,
    S,
    SS,
    SSR
}

[CreateAssetMenu(fileName ="NewRarity",menuName ="Card/Rarity")]
public class RarityData : ScriptableObject
{
    public RarityType rarityType;

    [Range(0f, 1f)]
    public float dropRate;

    public Color cardColor;

    public int sellPrice;
}
