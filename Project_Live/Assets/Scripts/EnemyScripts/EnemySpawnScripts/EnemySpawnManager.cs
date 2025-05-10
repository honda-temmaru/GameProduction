using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("生成するオブジェクト")]
    [SerializeField] GameObject enemyPrefab;
    [Header("オブジェクトの最大出現数（この数だけ、敵が常にステージ上にいる")]
    [SerializeField] int maxSpawnCount = 10;
    [Header("生成範囲")]
    [SerializeField] BoxCollider spawnArea;
    [Header("敵の数のチェック間隔")]
    [SerializeField] float checkInterval = 1.0f;

    EnemySpawn spawner;
    EnemyCountTracker tracker;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawner = new EnemySpawn(enemyPrefab, spawnArea);
        tracker = new EnemyCountTracker("Enemy");

        spawner.SpawnEnemies(maxSpawnCount);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < checkInterval) return;

        if (tracker.HasChanged(out int currentCount)) //敵の数に変化があったら
        {
            int toSpawn = maxSpawnCount - currentCount; //敵の設定総数と、現在の数の差分を求める

            if (toSpawn > 0) spawner.SpawnEnemies(toSpawn); //足りない数だけ敵を生成
        }
    }
}