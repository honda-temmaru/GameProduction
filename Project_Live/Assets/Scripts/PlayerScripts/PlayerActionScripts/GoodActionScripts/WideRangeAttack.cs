using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideRangeAttack : MonoBehaviour
{
    [Header("��������v���n�u")]
    [SerializeField] GameObject attackPrefab;

    [Header("�����ʒu")]
    [SerializeField] Transform generatePos;

    public void InstantiateWideRangeAttack()
    {
        Instantiate(attackPrefab, generatePos);
    }
}
