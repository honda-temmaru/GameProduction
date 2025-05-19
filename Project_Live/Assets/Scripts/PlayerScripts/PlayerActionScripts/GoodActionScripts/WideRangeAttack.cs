using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideRangeAttack : MonoBehaviour
{
    [Header("生成するプレハブ")]
    [SerializeField] GameObject attackPrefab;
    [Header("毎フレームに広がる量")]
    [SerializeField] float expandValue = 1f;
    [Header("生成位置")]
    [SerializeField] Transform generatePos;

    GameObject attack;
    float attackScale = 0f;

    void Update()
    {
        if (attack == null) return;

        attackScale += expandValue;

        attack.transform.localScale = new Vector3(attackScale, attack.transform.localScale.y, attackScale);
    }

    public void InstantiateWideRangeAttack()
    {
        attackScale = 0f;
        attack = Instantiate(attackPrefab, generatePos);
    }
}
