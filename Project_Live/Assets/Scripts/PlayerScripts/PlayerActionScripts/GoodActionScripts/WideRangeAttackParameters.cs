using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideRangeAttackParameters : MonoBehaviour
{
    [Header("–ˆƒtƒŒ[ƒ€‚ÉL‚ª‚é—Ê")]
    [SerializeField] float expandValue = 1f;

    float attackScale = 0f;

    void Update()
    {
        attackScale += expandValue * Time.deltaTime;

        transform.localScale = new Vector3(attackScale, transform.localScale.y, attackScale);
    }
}
