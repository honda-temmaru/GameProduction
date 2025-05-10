using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class EnemyStatus : CharacterStatus
{
    [Header("HPが0になってから消滅するまでの時間")]
    [SerializeField] float destroyDuration = 1f;

    [Header("死亡時のエフェクト")]
    [SerializeField] GameObject deathEffect;

    [Header("吹き飛ぶ力（奥）")]
    [SerializeField] float knockbackForce_Back = 5f;

    [Header("吹き飛ぶ力（上）")]
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

        Vector3 knockbackDirection = -transform.forward + Vector3.up * knockbackForce_Up;
        rb.AddForce(knockbackDirection.normalized * knockbackForce_Back, ForceMode.Impulse);

        Destroy(gameObject, destroyDuration);
    }
}
