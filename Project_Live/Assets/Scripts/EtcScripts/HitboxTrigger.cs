using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class HitboxTrigger : MonoBehaviour
{
    [Header("����������s���Ώۂ̃^�O")]
    [SerializeField] string targetTag = "Enemy";
    [Header("�����𔻒肷���")]
    [SerializeField] int MaxHitCount = 1;
    [Header("����������s�����Ԃ̊Ԋu")]
    [SerializeField] float hitIntervalTime = 0.5f;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] DamageToTarget damageToTarget;

    //�G���Ƃ̍Ō�ɍU�����������Ă���̌o�ߎ���
    Dictionary<Collider, float> hitIntervalTimers = new Dictionary<Collider, float>();
    
    //�G���Ƃ̍��܂ōU��������������
    Dictionary<Collider, int> hitCounts = new Dictionary<Collider, int>();

    void Update() //�o�ߎ��Ԃ̍X�V
    {
        var keys = new List<Collider>(hitIntervalTimers.Keys);

        foreach (var col in keys)
            hitIntervalTimers[col] += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(targetTag)) return;

        if (!hitCounts.ContainsKey(other)) //���߂čU�������������G�Ȃ�
        {
            hitCounts[other] = 0; //�����񐔂̃��Z�b�g
            hitIntervalTimers[other] = hitIntervalTime; //�o�ߎ��Ԃ̃��Z�b�g
        }

        if (hitCounts[other] >= MaxHitCount) return; //�����񐔂𐧌�����

        if (hitIntervalTimers[other] >= hitIntervalTime) //�q�b�g�\�Ȏ��Ԃ��o�߂��Ă����ꍇ
        {
   �@       damageToTarget?.TakeDamage(other.gameObject); //�_���[�W����
            damageToTarget?.ApplyKnockback(other.gameObject); //������я���

            hitIntervalTimers[other] = 0f; //�U��������̌o�ߎ��Ԃ����Z�b�g����
            hitCounts[other]++; //���݂̃q�b�g�񐔂𑝂₷

            //Debug.Log("����");
        }
    }

    void OnDisable()
    {
        //Debug.Log(currentHitCount + "�q�b�g");
        ResetHits();
    }

    public void ResetHits()
    {
        hitCounts.Clear();
        hitIntervalTimers.Clear();
    }
}
