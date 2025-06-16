using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ÒFŒKŒ´

public class ShotAttack : MonoBehaviour
{
    [Header("”­Ë‚·‚é’e")]
    [SerializeField] GameObject bulletPrefab;
    [Header("”­ËˆÊ’u")]
    [SerializeField] Transform shotPos;
    [Header("’e‚Ì‘¬“x")]
    [SerializeField] float bulletSpeed;
    [Header("”­Ë‚Ü‚Å‚ÌŠÔ")]
    [SerializeField] float chargeTime = 0.5f;
    [Header("”­ËŒãA“ü—Í‚ğÄ“xó‚¯•t‚¯‚é‚Ü‚Å‚ÌŠÔ")]
    [SerializeField] float shotInterval = 0.5f;
    [Header("’e‚ğ”­Ë‚µ‚Ä‚©‚ç‘¼‚Ìó‘Ô‚É‘JˆÚ‚·‚é‚Ü‚Å‚ÌŠÔ")]
    [SerializeField] float changeStateInterval = 0.5f;
    [Header("ˆÚ“®’†A’e‚ğ”­Ë‚Å‚«‚é‚©")]
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
            ShotBullet(); //ˆê’èŠÔŒo‰ß‚µ‚½‚ç”­Ë
            isCharging = false;
        }
    }

    void ShotBullet() //’e‚Ì¶¬E‰Á‘¬ˆ—
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPos.transform.position, shotPos.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shotPos.forward * bulletSpeed;

        timeSinceLastShot = 0f;
    }
}
