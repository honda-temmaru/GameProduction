using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParameter : MonoBehaviour
{
    [Header("��{�_���[�W")]
    [SerializeField] float baceDamage = 5f;
    [Header("��{�ƂȂ�O�����ւ̐�����΂���")]
    [SerializeField] float baceForwardKnockbackForce = 1f;
    [Header("��{�ƂȂ������ւ̐�����΂���")]
    [SerializeField] float baceUpwardKnockbackForce = 1f;
    [Header("�擾����R���|�[�l���g�̃I�u�W�F�N�g��")]
    [SerializeField] string objectName = "PlayerStatus";
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] DamageToTarget damageToTarget;

    GameObject player;
    PlayerStatus status;

    void Start()
    {
        player = GameObject.Find(objectName);

        if (player != null) status = player.GetComponent<PlayerStatus>();

        if (status != null) SetParameters();
    }

    void SetParameters() //�_���[�W�A������΂��͂�ݒ肷��
    {
        damageToTarget.Damage = GetDamage();
        damageToTarget.ForwardKnockbackForce = GetForwardForce();
        damageToTarget.UpwardKnockbackForce = GetUpwardForce();
    }

    float GetDamage() //�ŏI�I�ȃ_���[�W�ʂ��擾����
    {
        return player != null ? baceDamage * status.AttackPower : baceDamage;
    }

    float GetForwardForce() //�ŏI�I�ȏ�����ւ̐�����΂��͂��擾����
    {
        return player != null ? baceForwardKnockbackForce * status.AttackPower : baceForwardKnockbackForce;
    }

    float GetUpwardForce() //�ŏI�I�ȑO�����ւ̐�����΂��͂��擾����
    {
        return player != null ? baceUpwardKnockbackForce * status.AttackPower : baceUpwardKnockbackForce;
    }
}
