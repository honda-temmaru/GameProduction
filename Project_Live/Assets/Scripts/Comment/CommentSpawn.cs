//作成者:寺村

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommentSpawn : MonoBehaviour
{
    [Header("生成するオブジェクト")]
    [SerializeField] GameObject commentPrefab;
    [Header("ステージ")]
    [SerializeField] GameObject stage;
    [Header("生成する間隔")]
    [SerializeField] float spawnInterval = 2f;

    float time; //経過時間用変数
    List<Vector3> sideVertices = new List<Vector3>();   //ステージの側面座標を格納しておくList
    
    // Start is called before the first frame update
    void Start()
    {
        const float baseRadius = 0.5f;  //円柱の標準スケールの半径
        float radius = baseRadius * stage.transform.localScale.x;   //標準スケールにローカルスケールをかけることで半径が何倍になっているか求める

        var mesh=stage.GetComponent<MeshFilter>().mesh;
        var vertices = mesh.vertices;                       //unityでメッシュの頂点座標を取得する時のおまじない

        foreach (var v in vertices) //全ての頂点座標から側面頂点の座標だけをListに格納する繰り返し文
        {
            Vector3 worldV = stage.transform.TransformPoint(v);
            float r = Mathf.Sqrt(worldV.x * worldV.x + worldV.z * worldV.z);

            if (Mathf.Approximately(r, radius))
            {
                sideVertices.Add(worldV);
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnInterval)
        {
            DesideSpawnPos(sideVertices);
            time = 0f;
        }
    }

    void DesideSpawnPos(List<Vector3> sideVertices)
    {
        
        int random = Random.Range(0, sideVertices.Count);
        Debug.Log(random);

        Instantiate(commentPrefab, sideVertices[random], Quaternion.identity);
    }
}
