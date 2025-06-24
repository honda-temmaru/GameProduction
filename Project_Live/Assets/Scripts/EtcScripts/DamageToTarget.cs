using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class DamageToTarget : MonoBehaviour
{
    float damage;
    float forwardKnockbackForce;
    float upwardKnockbackForce;

    public float Damage { get { return damage; } set { damage = value; } }
    public float ForwardKnockbackForce { get { return forwardKnockbackForce; } set {  forwardKnockbackForce = value; } }
    public float UpwardKnockbackForce { get { return upwardKnockbackForce; } set { upwardKnockbackForce= value; } }

    public void TakeDamage(GameObject enemy) //�_���[�W��^����
    {
        EnemyStatus enemyStatus = enemy.GetComponent<EnemyStatus>();

        if (enemyStatus == null) return;

        enemyStatus.Hp -= damage;
        //Debug.Log(damage + "�_���[�W��^����");
    }

    public void ApplyKnockback(GameObject enemy) //������ԗ͂�������
    {
        Rigidbody rb = enemy.GetComponent<Rigidbody>();

        if (rb != null && !rb.isKinematic)
        {
            Vector3 forwardDirection = (enemy.transform.position - transform.position).normalized;

            Vector3 knockback = forwardDirection * forwardKnockbackForce + Vector3.up * upwardKnockbackForce;

            rb.AddForce(knockback, ForceMode.Impulse);
        }
    }
}
