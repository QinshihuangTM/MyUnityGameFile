using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//技能执行器
public class SkillExecutor
{
    public static int CalculateDamage(CardData attacker)
    {
        int baseDamage = attacker.attack;
        int skillBonus = (attacker.skill != null && attacker.skill.type == SkillType.Damage) ? attacker.skill.value : 0;
        return baseDamage + skillBonus;
    }

    public static void ExecuteSkill(CardData skillSource, BattleUnit target)
    {
        if (skillSource.skill == null) { return; }
        switch (skillSource.skill.type)
        {
            case SkillType.Heal:
                target.Heal(skillSource.skill.value); break;
            case SkillType.Damage:
                target.TakeDamage(skillSource.skill.value); break;
        }
    }
}
