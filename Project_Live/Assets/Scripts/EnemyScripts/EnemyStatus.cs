using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ÒFŒKŒ´

public class EnemyStatus : CharacterStatus
{
    private void Update()
    {
        if (Hp <= 0) Die();
    }

    void Die()
    {
        //Debug.Log("“|‚µ‚½");
        Destroy(gameObject);
    }
}
