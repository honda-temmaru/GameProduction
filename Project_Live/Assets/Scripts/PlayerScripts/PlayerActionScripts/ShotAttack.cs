using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class ShotAttack : MonoBehaviour
{
    [Header("���˂���e")]
    [SerializeField] GameObject bulletPrefab;
    [Header("���ˈʒu")]
    [SerializeField] Transform shotPos;
    [Header("�e�̑��x")]
    [SerializeField] float bulletSpeed;
    [Header("���˂܂ł̎���")]
    [SerializeField] float chargeTime = 0.5f;
    [Header("���ˌ�A���͂��ēx�󂯕t����܂ł̎���")]
    [SerializeField] float shotInterval = 0.5f;
    [Header("�e�𔭎˂��Ă��瑼�̏�ԂɑJ�ڂ���܂ł̎���")]
    [SerializeField] float changeStateInterval = 0.5f;
    [Header("�ړ����A�e�𔭎˂ł��邩")]
    [SerializeField] bool canMovingShot = false;    

    float timeSinceLastShot = 0f;
    bool isCharging = false;
    bool hasPlayAnim = false;
    float currentChargeTime = 0f;

    public float ShotInterval { get { return shotInterval; } }
    public float ChangeStateInterval { get { return changeStateInterval; } }
    public bool CanMovingShot { get { return canMovingShot; } }
    public float TimeSinceLastShot { get { return timeSinceLastShot; } set { timeSinceLastShot = value; } }
    public bool IsCharging { get { return isCharging; } }
    public bool HasPlayAnim { get {  return hasPlayAnim; } set { hasPlayAnim = value; } }

    public void TryShot()
    {
        if (timeSinceLastShot < shotInterval || isCharging) return;

        hasPlayAnim = true;
        isCharging = true;
        currentChargeTime = 0f;
    }

    public void ShotAttackProcess()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!isCharging) return;

        currentChargeTime += Time.deltaTime;

        if (currentChargeTime >= chargeTime)
        {
            ShotBullet(); //��莞�Ԍo�߂����甭��
            isCharging = false;
        }
    }

    void ShotBullet() //�e�̐����E��������
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPos.transform.position, shotPos.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shotPos.forward * bulletSpeed;

        timeSinceLastShot = 0f;
    }
}
