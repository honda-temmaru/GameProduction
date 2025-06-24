using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuosHitAttack : MonoBehaviour
{
    [Header("��������U����������I�u�W�F�N�g")]
    [SerializeField] GameObject hitboxPrefab;
    [Header("�����ʒu")]
    [SerializeField] Transform generatePos;

    public void GenerateAttack()
    {
        Instantiate(hitboxPrefab, generatePos.transform.position, generatePos.transform.rotation);
    }
}
