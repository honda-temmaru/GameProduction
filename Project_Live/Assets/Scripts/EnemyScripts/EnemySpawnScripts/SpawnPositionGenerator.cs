using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionGenerator
{
    BoxCollider spawnArea;

    public SpawnPositionGenerator(BoxCollider spawnArea)
    {
        this.spawnArea = spawnArea;
    }

    public Vector3 GetRandomPositionInsideCollider() //ê∂ê¨à íuÇÃéÊìæ
    {
        Vector3 center = spawnArea.center + spawnArea.transform.position;
        Vector3 size = Vector3.Scale(spawnArea.size, spawnArea.transform.lossyScale);

        float x = Random.Range(-size.x / 2, size.x / 2);
        float z = Random.Range(-size.z / 2, size.z / 2);
        float y = 0f;

        return center + new Vector3(x, y, z);
    }
}