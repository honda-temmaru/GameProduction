using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

[System.Serializable]
class ComboStep
{
    [Header("この段の攻撃判定用オブジェクト")]
    [SerializeField] public GameObject hitbox;
    [Header("この攻撃が与える基本ダメージ")]
    [SerializeField] public float baseDamage = 10f;
    [Header("当たり判定の持続時間")]
    [SerializeField] public float attackDuration = 0.2f;
    [Header("攻撃判定消滅後、次の段に移行可能な猶予時間")]
    [SerializeField] public float comboResetTime = 1f;
    [Header("入力受け付後から攻撃までの時間")]
    [SerializeField] public float windupTime = 0.2f;
    [Header("この段の攻撃時に移動する距離")]
    [SerializeField] public float attackMoveDistance = 1f;
}

public class CloseAttack : MonoBehaviour
{
    [Header("移動を制御するオブジェクト")]
    [SerializeField] Transform target;
    [Header("コンボ設定")]
    [SerializeField] List<ComboStep> comboSteps = new List<ComboStep>();

    [Header("必要なコンポーネント")]
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] DamageToEnemy damageToEnemy;
    [SerializeField] MovePlayer movePlayer;

    public enum AttackState { None, Windup, Attacking, Recovering }

    AttackState attackState = AttackState.None;

    int currentComboIndex = 0; //現在のコンボ段階を示す変数
    float lastAttackTime = 0f; //最後に攻撃した時間
    bool isAttackBuffered = false; //攻撃入力があったかどうか
    float stateTimer = 0f; //各状態の経過時間の計測用

    float moveSpeedMultiplier = 1f; //攻撃中の移動即と制限用
    float movedDistance = 0f;
    float totalMoveDistance = 0f;

    public AttackState CurrentAttackState { get { return attackState; } private set { attackState = value; } }

    public void TryAttack() //攻撃処理（近接攻撃ボタンを押したときに呼ばれる）
    {
        if (isAttackBuffered || currentComboIndex >= comboSteps.Count) return;

        isAttackBuffered = true;
        movePlayer.MoveSpeedMultiplier = 0f; //移動を制限
        stateTimer = 0f;
        attackState = AttackState.Windup;

        ComboStep step = comboSteps[currentComboIndex];
        totalMoveDistance = step.attackMoveDistance;
        movedDistance = 0f;
        
        //Debug.Log(currentComboIndex + 1 + "段目");
    }

    void Update()
    {
        stateTimer += Time.deltaTime;

        HandleAttackMovement();

        switch (attackState)
        {
            case AttackState.Windup: //攻撃待機
                if (stateTimer >= comboSteps[currentComboIndex].windupTime)
                    BeginAttack();
                break;

            case AttackState.Attacking: //攻撃中
                if (stateTimer >= comboSteps[currentComboIndex].attackDuration)
                    EndAttack();
                break;

            case AttackState.Recovering: //攻撃後
                if (Time.time - lastAttackTime > GetCurrentComboResetTime())
                    ResetCombo();
                break;
        }
    }    

    void BeginAttack() //攻撃開始時の処理
    {
        ComboStep step = comboSteps[currentComboIndex];

        damageToEnemy.Damage = GetCurrentDamage();

        if (step.hitbox != null) step.hitbox.SetActive(true);

        movePlayer.RotationSpeedMultiplier = 0f;
        
        stateTimer = 0f;
        attackState = AttackState.Attacking;

        //Debug.Log(currentComboIndex + 1 + "段目発生");
    }

    void EndAttack() //発生した攻撃の終了処理
    {
        ComboStep step = comboSteps[currentComboIndex];

        if (step.hitbox != null) step.hitbox.SetActive(false);

        movePlayer.RotationSpeedMultiplier = 1f;

        lastAttackTime = Time.time;      
        isAttackBuffered = false;
        stateTimer = 0f;
        attackState = AttackState.Recovering;

        //Debug.Log(currentComboIndex + 1 + "段目終了");
        currentComboIndex++;
    }

    void ResetCombo() //コンボ段階の初期化
    {
        //各当たり判定の無効化
        foreach (var step in comboSteps)
            if (step.hitbox != null)　step.hitbox.SetActive(false);

        movePlayer.MoveSpeedMultiplier = 1f;
        isAttackBuffered = false;
        stateTimer = 0f;
        attackState = AttackState.None;        

        //Debug.Log(currentComboIndex + "コンボのリセット");
        currentComboIndex = 0;
    }

    float GetCurrentComboResetTime() //次のコンボ段階までの猶予時間の取得
    {
        return comboSteps[currentComboIndex - 1].comboResetTime;
    }

    void HandleAttackMovement() //攻撃時の前進処理
    {
        if (attackState != AttackState.Windup || currentComboIndex >= comboSteps.Count) return;

        ComboStep step = comboSteps[currentComboIndex];

        float duration = step.windupTime; //windupTimeの間に前進を終える
        float movePerSecond = totalMoveDistance / duration;
        float moveDelta = movePerSecond * Time.deltaTime;

        float remaining = totalMoveDistance - movedDistance;
        float actualMove = Mathf.Min(moveDelta, remaining);

        target.position += target.forward.normalized * actualMove;
        movedDistance += actualMove;
    }

    float GetCurrentDamage() //現在の段のダメージ量を取得する
    {
        if (currentComboIndex >= comboSteps.Count || currentComboIndex < 0) return 0f;

        ComboStep step = comboSteps[currentComboIndex];
        float attackPower = playerStatus != null ? playerStatus.AttackPower : 1f;

        return step.baseDamage * attackPower; //現在の段の基本ダメージとプレイヤーの攻撃力から最終ダメージを乗算
    }
}
