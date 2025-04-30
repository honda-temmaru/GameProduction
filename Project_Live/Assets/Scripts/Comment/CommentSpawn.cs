//作成者:寺村

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
class SpawnInterval //スポーン時間のプロパティ用クラス
{
    [Header("スポーンまでの時間")]
    [SerializeField] public float time;
    [Header("このスポーン時間までに必要ないいね数")]
    [SerializeField] public float needGoodNum;
}


public class CommentSpawn : MonoBehaviour
{
    [Header("生成するオブジェクト")]
    [SerializeField] GameObject commentPrefab;
    [Header("ステージ")]
    [SerializeField] GameObject stage;
    [Header("スポーン時間設定")]
    [SerializeField]List<SpawnInterval> spawnInterval=new List<SpawnInterval>();
    [Header("必要なコンポーネント")]
    [SerializeField]GoodSystem goodSystem;

    int spawnIntervalCurrentIndex = 0;  //現在のspawnIntervalの要素数
    float spawnTimer; //スポーン時間計測用変数
    List<Vector3> sideVertices = new List<Vector3>();   //ステージの側面座標を格納しておくList
    SpawnInterval currentInterval = new SpawnInterval();    //現在のスポーン時間と必要ないいね数を設定しておくインスタンス


    // Start is called before the first frame update
    void Start()
    {
        GetSideVertices(stage, sideVertices);   //開始時にステージの側面座標を取得
        currentInterval = spawnInterval[spawnIntervalCurrentIndex];     //初期のスポーン時間を設定
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;   //スポーンまでの時間を計測

        if(spawnIntervalCurrentIndex+1<spawnInterval.Count)
        {
                if (goodSystem.GoodNum >= spawnInterval[spawnIntervalCurrentIndex+1].needGoodNum)   //いいね数が次の段階に達したら処理
                {
                    spawnIntervalCurrentIndex++;
                    currentInterval = spawnInterval[spawnIntervalCurrentIndex];
                    Debug.Log("いいね数が"+currentInterval.needGoodNum+"を超えたのでスポーン時間を"+currentInterval.time+"秒に変更しました");
                }
        }

        if (spawnTimer >= currentInterval.time)
        {
            DesideSpawnPos(sideVertices);
            spawnTimer = 0f;
        }
    }

    void DesideSpawnPos(List<Vector3> sideVertices) //側面座標からランダムに生成座標を選ぶ関数
    {
        int random = Random.Range(0, sideVertices.Count);
        //Debug.Log(random);

        Instantiate(commentPrefab, sideVertices[random], Quaternion.identity);
    }

    void GetSideVertices(GameObject stage,List<Vector3>sideVertices)    //側面の頂点座標を取得する関数
    {
        const float baseRadius = 0.5f;  //円柱の標準スケールの半径
        float radius = baseRadius * stage.transform.localScale.x;   //標準スケールにローカルスケールをかけることで半径が何倍になっているか求める

        var mesh = stage.GetComponent<MeshFilter>().mesh;
        var vertices = mesh.vertices;                       //unityでメッシュの頂点座標を取得する時のおまじない

        foreach (var v in vertices) //全ての頂点座標から側面頂点の座標だけをListに格納する繰り返し文
        {
            Vector3 worldV = stage.transform.TransformPoint(v); //ステージのtransformをローカル座標からワールド座標に変更
            float r = Mathf.Sqrt(worldV.x * worldV.x + worldV.z * worldV.z);    //調べている頂点の中心からの距離を求める

            if (Mathf.Approximately(r, radius))     //中心からの距離がステージの半径と近似なら側面の座標としてlistに追加
            {
                sideVertices.Add(worldV);
            }
        }
    }
}
