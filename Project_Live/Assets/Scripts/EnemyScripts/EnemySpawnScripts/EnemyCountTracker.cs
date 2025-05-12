using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountTracker : MonoBehaviour
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

        if (currentCount != prev_Count)
        {
            prev_Count = currentCount;
            return true;
        }

        return false;
    }
}
