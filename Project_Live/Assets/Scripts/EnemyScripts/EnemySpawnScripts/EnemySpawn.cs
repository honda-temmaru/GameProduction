using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn
{
    GameObject enemyPrefab;
    SpawnPositionGenerator spawnPositionGenerator;

    public EnemySpawn(GameObject enemyPrefab, BoxCollider spawnArea)
    {
        this.enemyPrefab = enemyPrefab;
        this.spawnPositionGenerator = new SpawnPositionGenerator(spawnArea);
    }

    public void SpawnEnemies(int count) //ìGÇÃê∂ê¨
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = spawnPositionGenerator.GetRandomPositionInsideCollider();
            GameObject.Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }    
}
