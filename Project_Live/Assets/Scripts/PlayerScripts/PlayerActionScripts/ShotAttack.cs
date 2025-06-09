using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ŽÒFŒKŒ´

public class ShotAttack : MonoBehaviour
{
    [Header("”­ŽË‚·‚é’e")]
    [SerializeField] GameObject bulletPrefab;
    [Header("”­ŽËˆÊ’u")]
    [SerializeField] Transform shotPos;
    [Header("’e‚Ì‘¬“x")]
    [SerializeField] float bulletSpeed;
    [Header("”­ŽË‚Ü‚Å‚ÌŽžŠÔ")]
    [SerializeField] float shotInterval = 0.5f;

    float timeSinceLastShot = 0f;

    public void ShotAttackProcess()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shotInterval) ShotBullet();
    }

    void ShotBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPos.transform.position, shotPos.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shotPos.forward * bulletSpeed;

        timeSinceLastShot = 0f;

        PlayerInputEvents.IdleInput();
    }
}
