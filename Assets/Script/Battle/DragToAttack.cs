using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragToAttack : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public BattleUnit attackerUnit;
    private Vector3 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPosition;

        if (attackerUnit == null)
        {
            Debug.LogError("⚠️ attackerUnit 未赋值！");
            return;
        }

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var hit in results)
        {
            BattleUnit target = hit.gameObject.GetComponent<BattleUnit>();
            if (target != null && target != attackerUnit)
            {
                int damage = SkillExecutor.CalculateDamage(attackerUnit.cardData);
                target.TakeDamage(damage);

                // 禁止再次拖动
                attackerUnit.GetComponent<DragToAttack>().enabled = false;

                // 敌方反击逻辑
                BattleManager.Instance.OnPlayerAttackComplete();
                return;
            }
        }
    }
}
