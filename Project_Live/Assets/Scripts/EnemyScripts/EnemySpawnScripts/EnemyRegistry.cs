using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyRegistry
{
    static Dictionary<EnemyType, int> enemyCounts = new();

    public static void Register(EnemyType type) //指定された種類の敵のカウントを増やす
    {
        if (!enemyCounts.ContainsKey(type))
            enemyCounts[type] = 0;

        enemyCounts[type]++;
    }

    public static void Unregister(EnemyType type) //指定された種類の敵のカウントを減らす
    {
        if (!enemyCounts.ContainsKey(type)) return;

        enemyCounts[type]--;

        if (enemyCounts[type] <= 0) enemyCounts[type] = 0;
     }

    public static int GetCount(EnemyType type) //指定された種類の敵が現在存在している数を取得する
    {
        return enemyCounts.TryGetValue(type, out var count) ? count : 0;
    }
}