using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Damage,
    Heal,
    Shield,//提供护盾
    Buff,
    Debuff
}

[CreateAssetMenu(fileName = "NewSkill",menuName ="Card/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;

    [TextArea]
    public string description;

    public SkillType type;
    public int value;
    //public int cooldown;
}
