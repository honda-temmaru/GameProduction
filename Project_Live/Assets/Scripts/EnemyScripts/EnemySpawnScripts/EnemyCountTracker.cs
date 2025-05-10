using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountTracker : MonoBehaviour
{
    string enemyTag;
    int prev_Count;

    public EnemyCountTracker(string enemyTag)
    {
        this.enemyTag = enemyTag;
        prev_Count = 0;
    }

    int GetCurrentCount() //Enemyタグをもつオブジェクトの数を調べる
    {
        return GameObject.FindGameObjectsWithTag(enemyTag).Length;
    }

    public bool HasChanged(out int currentCount) //敵の数が変わったどうか判定する
    {
        currentCount = GetCurrentCount();

        if (currentCount !=  prev_Count)
        {
            prev_Count = currentCount;
            return true;
        }

        return false;
    }
}
