using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class LongRangeAttack : MonoBehaviour
{
    [Header("��������U����������I�u�W�F�N�g")]
    [SerializeField] GameObject bulletPrefab;
    [Header("���ˈʒu")]
    [SerializeField] Transform shotPos;

    public void ShotBeam()
    {
        Instantiate(bulletPrefab, shotPos.transform.position, shotPos.transform.rotation);
    }
}
