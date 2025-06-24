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

    public bool HasChanged(out int currentCount) //“G‚Ì”‚ª•Ï‚í‚Á‚½‚Ç‚¤‚©”»’è‚·‚é
    {
        currentCount = EnemyRegistry.GetCount(enemyType);

        //Debug.Log(enemyType + ":" + currentCount);

        if (currentCount != prev_Count)
        {
            //Debug.Log(enemyType + "‚Ì”‚ª•Ï‰»‚µ‚½");
            prev_Count = currentCount;
            return true;
        }

        return false;
    }
}
