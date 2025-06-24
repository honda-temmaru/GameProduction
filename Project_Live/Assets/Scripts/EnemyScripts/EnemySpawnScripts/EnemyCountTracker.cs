using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class EnemyCountTracker
{
    EnemyType enemyType;
    int prev_Count;

    public EnemyCountTracker(EnemyType enemyType)
    {
        this.enemyType = enemyType;
        prev_Count = -1;
    }

    public bool HasChanged(out int currentCount) //�G�̐����ς�����ǂ������肷��
    {
        currentCount = EnemyRegistry.GetCount(enemyType);

        //Debug.Log(enemyType + ":" + currentCount);

        if (currentCount != prev_Count)
        {
            //Debug.Log(enemyType + "�̐����ω�����");
            prev_Count = currentCount;
            return true;
        }

        return false;
    }
}
