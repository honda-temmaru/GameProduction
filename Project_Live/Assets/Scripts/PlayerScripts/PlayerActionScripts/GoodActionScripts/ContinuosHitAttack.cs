using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuosHitAttack : MonoBehaviour
{
    [Header("生成する攻撃判定をもつオブジェクト")]
    [SerializeField] GameObject hitboxPrefab;
    [Header("生成位置")]
    [SerializeField] Transform generatePos;

    public void GenerateAttack()
    {
        Instantiate(hitboxPrefab, generatePos.transform.position, generatePos.transform.rotation);
    }
}
