using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class DamageToEnemy : MonoBehaviour
{
    float damage;
    float knockbackForce;

    public float Damage { get { return damage; } set { damage = value; } }
    public float KnockbackForce { get { return knockbackForce; } set {  knockbackForce = value; } }

    public void TakeDamage(GameObject enemy)
    {
        EnemyStatus enemyStatus = enemy.GetComponent<EnemyStatus>();

        if (enemyStatus == null)
        {
            Debug.LogWarning("対象が見つかりません");
            return;
        }

        enemyStatus.Hp -= damage;
        //Debug.Log(damage + "ダメージを与えた");
    }

    public void ApplyKnockback(GameObject enemy)
    {
        Rigidbody rb = enemy.GetComponent<Rigidbody>();

        if (rb != null && !rb.isKinematic)
        {
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
            rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }
    }
}
