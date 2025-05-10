using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class DamageToEnemy : MonoBehaviour
{
    float damage;

    public float Damage { get { return damage; } set { damage = value; } }

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
}
