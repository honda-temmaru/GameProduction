using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class HitboxTrigger : MonoBehaviour
{
    [SerializeField] string targetTag = "Enemy";
    [SerializeField] DamageToEnemy damageToEnemy;

    HashSet<Collider> hitTargets = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && !hitTargets.Contains(other))
        {
            if (damageToEnemy != null)
            {
                damageToEnemy.TakeDamage(other.gameObject); //ダメージ処理
                damageToEnemy.ApplyKnockback(other.gameObject); //吹き飛び処理
            }

            //Debug.Log("命中");
            hitTargets.Add(other);
        }
    }

    private void OnDisable()
    {
        ResetHits();
    }

    public void ResetHits()
    {
        hitTargets.Clear();
    }
}
