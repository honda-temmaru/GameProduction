using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideRangeAttack : MonoBehaviour
{
    [Header("生成するプレハブ")]
    [SerializeField] GameObject attackPrefab;

    [Header("生成位置")]
    [SerializeField] Transform generatePos;

    public void InstantiateWideRangeAttack()
    {
        Instantiate(attackPrefab, generatePos);
    }
}
