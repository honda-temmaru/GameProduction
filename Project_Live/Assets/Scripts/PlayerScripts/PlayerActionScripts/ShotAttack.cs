using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//çÏê¨é“ÅFåKå¥

public class ShotAttack : MonoBehaviour
{
    [Header("î≠éÀÇ∑ÇÈíe")]
    [SerializeField] GameObject bulletPrefab;
    [Header("î≠éÀà íu")]
    [SerializeField] Transform shotPos;
    [Header("íeÇÃë¨ìx")]
    [SerializeField] float bulletSpeed;
    [Header("çƒî≠éÀÇ‹Ç≈ÇÃä‘äu")]
    [SerializeField] float shotInterval = 0.5f;

    float timeSinceLastShot = 0f;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    public void ShotBullet()
    {
        if (timeSinceLastShot < shotInterval) return;

        GameObject bullet = Instantiate(bulletPrefab, shotPos.transform.position, shotPos.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shotPos.forward * bulletSpeed;

        timeSinceLastShot = 0f;
    }
}
