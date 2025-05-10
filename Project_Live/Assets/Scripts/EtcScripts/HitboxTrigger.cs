using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//çÏê¨é“ÅFåKå¥

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
                damageToEnemy.TakeDamage(other.gameObject);

            //Debug.Log("ñΩíÜ");
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
