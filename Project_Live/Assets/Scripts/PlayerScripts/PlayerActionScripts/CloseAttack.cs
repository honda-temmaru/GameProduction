using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

[System.Serializable]
class ComboStep
{
    [Header("�U������p�I�u�W�F�N�g")]
    [SerializeField] public GameObject hitbox;
    [Header("��{�_���[�W")]
    [SerializeField] public float baseDamage = 10f;
    [Header("�O�����ւ̊�{�̐�����΂���")]
    [SerializeField] public float baceForwardKnockbackForce = 1f;
    [Header("������ւ̊�{�̐�����΂���")]
    [SerializeField] public float baceUpwardKnockbackForce = 1f;
    [Header("�����蔻��̎�������")]
    [SerializeField] public float attackDuration = 0.2f;
    [Header("�U��������Ō�A���̒i�Ɉڍs�\�ȗP�\����")]
    [SerializeField] public float comboResetTime = 1f;
    [Header("���͎󂯕t�ォ��U���܂ł̎���")]
    [SerializeField] public float windupTime = 0.2f;
    [Header("�U�����Ɉړ����鋗��")]
    [SerializeField] public float attackMoveDistance = 1f;
}

public class CloseAttack : MonoBehaviour
{
    [Header("�ړ��𐧌䂷��I�u�W�F�N�g")]
    [SerializeField] Transform target;
    [Header("�R���{�ݒ�")]
    [SerializeField] List<ComboStep> comboSteps = new List<ComboStep>();

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] DamageToTarget damageToTarget;
    [SerializeField] MovePlayer movePlayer;

    public enum AttackState { None, Windup, Attacking, Recovering }

    AttackState attackState = AttackState.None;

    int currentComboIndex = 0; //���݂̃R���{�i�K�������ϐ�
    float lastAttackTime = 0f; //�Ō�ɍU����������
    bool isAttackBuffered = false; //�U�����͂����������ǂ���
    float stateTimer = 0f; //�e��Ԃ̌o�ߎ��Ԃ̌v���p

    float movedDistance = 0f;
    float totalMoveDistance = 0f;

    public AttackState CurrentAttackState { get { return attackState; } private set { attackState = value; } }
    public int CurrentComboIndex { get { return currentComboIndex; } }

    public void TryAttack() //�U�������i�ߐڍU���{�^�����������Ƃ��ɌĂ΂��j
    {
        if (isAttackBuffered || currentComboIndex >= comboSteps.Count) return;

        isAttackBuffered = true;
        movePlayer.MoveSpeedMultiplier = 0f; //�ړ��𐧌�
        //stateTimer = 0f;
        attackState = AttackState.Windup;

        ComboStep step = comboSteps[currentComboIndex];
        totalMoveDistance = step.attackMoveDistance;
        movedDistance = 0f;
        
        //Debug.Log(currentComboIndex + 1 + "�i��");
    }

    public void CloseAttackProcess()
    {
        stateTimer += Time.deltaTime;

        HandleAttackMovement();

        switch (attackState)
        {
            case AttackState.Windup: //�U���ҋ@
                if (stateTimer >= comboSteps[currentComboIndex].windupTime)
                    BeginAttack();
                break;

            case AttackState.Attacking: //�U����
                if (stateTimer >= comboSteps[currentComboIndex].attackDuration)
                    EndAttack();
                break;

            case AttackState.Recovering: //�U����
                if (Time.time - lastAttackTime > GetCurrentComboResetTime())
                    ResetCombo();
                break;

            case AttackState.None:
                break;
        }
    }

    void BeginAttack() //�U���J�n���̏���
    {
        ComboStep step = comboSteps[currentComboIndex];

        damageToTarget.Damage = GetCurrentDamage(); //�^����_���[�W�̑��
        damageToTarget.ForwardKnockbackForce = GetCurrentForwardForce(); //�O�����֐�����΂��͂̑��
        damageToTarget.UpwardKnockbackForce = GetCurrentUpwardForce(); //������֐�����΂��͂̑��

        if (step.hitbox != null) step.hitbox.SetActive(true); //�U������̗L����

        movePlayer.RotationSpeedMultiplier = 0f; //�v���C���[�̉�]�X�s�[�h�̐���
        
        stateTimer = 0f;
        attackState = AttackState.Attacking;

        //Debug.Log(currentComboIndex + 1 + "�i�ڔ���");
    }

    void EndAttack() //���������U���̏I������
    {
        ComboStep step = comboSteps[currentComboIndex];

        if (step.hitbox != null) step.hitbox.SetActive(false); //�U������̖�����

        movePlayer.RotationSpeedMultiplier = 1f;

        lastAttackTime = Time.time;      
        isAttackBuffered = false;
        stateTimer = 0f;
        attackState = AttackState.Recovering;

        //Debug.Log(currentComboIndex + 1 + "�i�ڏI��");
        currentComboIndex++;
    }

    void ResetCombo() //�R���{�i�K�̏�����
    {
        //�e�����蔻��̖�����
        foreach (var step in comboSteps)
            if (step.hitbox != null)�@step.hitbox.SetActive(false);

        movePlayer.MoveSpeedMultiplier = 1f;
        isAttackBuffered = false;
        stateTimer = 0f;
        attackState = AttackState.None;        

        //Debug.Log(currentComboIndex + "�R���{�̃��Z�b�g");
        currentComboIndex = 0;
        PlayerActionEvents.IdleEvent();
    }

    float GetCurrentComboResetTime() //���̃R���{�i�K�܂ł̗P�\���Ԃ̎擾
    {
        return comboSteps[currentComboIndex - 1].comboResetTime;
    }

    void HandleAttackMovement() //�U�����̑O�i����
    {
        if (attackState != AttackState.Windup || currentComboIndex >= comboSteps.Count) return;

        ComboStep step = comboSteps[currentComboIndex];

        float duration = step.windupTime; //windupTime�̊ԂɑO�i���I����
        float movePerSecond = totalMoveDistance / duration;
        float moveDelta = movePerSecond * Time.deltaTime;

        float remaining = totalMoveDistance - movedDistance;
        float actualMove = Mathf.Min(moveDelta, remaining);

        target.position += target.forward.normalized * actualMove;
        movedDistance += actualMove;
    }

    float GetCurrentDamage() //���݂̒i�̃_���[�W�ʂ��擾����
    {
        if (currentComboIndex >= comboSteps.Count || currentComboIndex < 0) return 0f;

        ComboStep step = comboSteps[currentComboIndex];
        float attackPower = playerStatus != null ? playerStatus.AttackPower : 1f;

        return step.baseDamage * attackPower; //�ŏI�I�ȃ_���[�W�ʂ�Ԃ�
    }

    float GetCurrentForwardForce() //���݂̍U���̑O�����ւ̐�����΂��͂��擾����
    {
        if (currentComboIndex >= comboSteps.Count || currentComboIndex < 0) return 0f;

        ComboStep step = comboSteps[currentComboIndex];
        float attackPower = playerStatus != null ? playerStatus.AttackPower : 1f;

        return step.baceForwardKnockbackForce * attackPower; //�ŏI�I�ȑO�����ւ̐�����΂��͂�Ԃ�
    }

    float GetCurrentUpwardForce() //���݂̍U���̏�����ւ̐�����΂��͂��擾����
    {
        if (currentComboIndex >= comboSteps.Count || currentComboIndex < 0) return 0f;

        ComboStep step = comboSteps[currentComboIndex];
        float attackPower = playerStatus != null ? playerStatus.AttackPower : 1f;

        return step.baceUpwardKnockbackForce * attackPower; //�ŏI�I�ȑO�����ւ̐�����΂��͂�Ԃ�
    }
}
