using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

[System.Serializable]
class ComboStep
{
    [Header("この段の攻撃判定用オブジェクト")]
    [SerializeField] public GameObject hitbox;
    [Header("当たり判定の持続時間")]
    [SerializeField] public float attackDuration = 0.2f;
    [Header("次の段に移行可能な猶予時間（超過すると初段に戻る)")]
    [SerializeField] public float comboResetTime = 1f;   
}

public class CloseAttack : MonoBehaviour
{
    [Header("コンボ設定")]
    [SerializeField] List<ComboStep> comboSteps = new List<ComboStep>();    

    int currentComboIndex = 0; //現在のコンボ段階を示す変数
    float lastAttackTime = 0f; //最後に攻撃した時間
    float attackTimer = 0f; //当たり判定の持続時間用変数
    bool isAttacking = false; //現在攻撃しているかどうか

    void Update()
    {
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
                EndAttack();
        }

        if (!isAttacking && currentComboIndex != 0 && Time.time - lastAttackTime > GetCurrentComboResetTime())
            ResetCombo();
    }

    public void TryAttack() //攻撃処理
    {
        if (isAttacking) return;

        if (currentComboIndex < comboSteps.Count)
        {
            ComboStep step = comboSteps[currentComboIndex];

            if (step.hitbox != null)
                step.hitbox.SetActive(true);

            attackTimer = step.attackDuration;
            isAttacking = true;

            currentComboIndex++;
            lastAttackTime = Time.time;
        }
    }

    void EndAttack() //発生した攻撃の終了処理
    {
        int prevIndex = currentComboIndex - 1;

        if (prevIndex >= 0 && prevIndex < comboSteps.Count)
        {
            var step = comboSteps[prevIndex];

            if (step.hitbox != null)
                step.hitbox.SetActive(false);
        }

        isAttacking = false;
    }

    void ResetCombo() //コンボ段階の初期化
    {
        currentComboIndex = 0;
        isAttacking = false;
        attackTimer = 0f;

        //各当たり判定の無効化
        foreach (var step in comboSteps)
        {
            if (step.hitbox != null)
                step.hitbox.SetActive(false);
        }
    }

    float GetCurrentComboResetTime() //次のコンボ段階までの猶予時間の取得
    {
        return comboSteps[currentComboIndex - 1].comboResetTime;
    }
}
