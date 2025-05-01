using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 3;
    public BoxCollider spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPosition = GetRandomPositionCollider(spawnArea);

            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 GetRandomPositionCollider(BoxCollider box)
    {
        Vector3 center = box.center + box.transform.position;
        Vector3 size = box.size;
        size = Vector3.Scale(size, box.transform.lossyScale);
        float x = Random.Range(-size.x / 2, size.x / 2);
        float z = Random.Range(-size.z / 2, size.z / 2);
        float y = 0f;
        return center + new Vector3(x, y, z);
    }
}
