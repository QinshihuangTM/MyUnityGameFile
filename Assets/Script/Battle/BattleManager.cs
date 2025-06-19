using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public BattleUnit playerUnit;
    public BattleUnit enemyUnit;

    public GameObject victoryPanel;
    public GameObject defeatPanel;


    private void Awake()
    {
        Instance = this;
    }

    public void StartBattle(CardData playerCard, CardData enemyCard)
    {
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        playerUnit.Init(playerCard);
        enemyUnit.Init(enemyCard);
    }

    public void OnPlayerAttackComplete()
    {
        if (enemyUnit.IsDead())
        {
            victoryPanel.SetActive(true);
            return;
        }

        Invoke(nameof(EnemyAttack), 1f); // 模拟敌方 AI 延迟攻击
    }

    private void EnemyAttack()
    {
        int damage = SkillExecutor.CalculateDamage(enemyUnit.cardData);
        playerUnit.TakeDamage(damage);

        if (playerUnit.IsDead())
        {
            defeatPanel.SetActive(true);
            return;
        }

        //重新启用我方拖动，进入新一轮回合
        playerUnit.GetComponent<DragToAttack>().enabled = true;
    }

}
