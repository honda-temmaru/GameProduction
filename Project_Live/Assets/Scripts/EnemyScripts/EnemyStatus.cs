using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class EnemyStatus : CharacterStatus
{
    [Header("HP��0�ɂȂ��Ă�����ł���܂ł̎���")]
    [SerializeField] float destroyDuration = 1f;

    [Header("���S���̃G�t�F�N�g")]
    [SerializeField] GameObject deathEffect;

    [Header("������ԗ́i���j")]
    [SerializeField] float knockbackForce_Back = 5f;

    [Header("������ԗ́i��j")]
    [SerializeField] float knockbackForce_Up = 0.5f;

    bool isDead = false;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isDead && Hp <= 0) Die();
    }

    void Die()
    {
        isDead = true;

        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);

        // ������я����i�O���� + ��������ʂɉ��Z�j
        Vector3 backwardForce = -transform.forward * knockbackForce_Back;
        Vector3 upwardForce = Vector3.up * knockbackForce_Up;

        // �������ēK�p
        rb.AddForce(backwardForce + upwardForce, ForceMode.Impulse);

        Destroy(gameObject, destroyDuration);
    }
}
