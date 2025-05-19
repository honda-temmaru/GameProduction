using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class LongRangeAttack : MonoBehaviour
{
    [Header("生成する攻撃判定をもつオブジェクト")]
    [SerializeField] GameObject bulletPrefab;
    [Header("発射位置")]
    [SerializeField] Transform shotPos;

    public void ShotBeam()
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPos.transform.position, shotPos.transform.rotation);
    }
}
