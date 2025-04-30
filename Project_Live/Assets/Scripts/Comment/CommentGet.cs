//作成者:寺村

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentGet : MonoBehaviour
{
    GoodSystem goodSystem;
    bool getTrigger = false;    //2重取り防ぎ用のフラグ

    // Start is called before the first frame update
    void Start()
    {
        goodSystem= GameObject.FindWithTag("GoodSystem").GetComponent<GoodSystem>();    //スクリプトGoodSystemの変数を扱うためのおまじない
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (getTrigger)
            return;
        if (other.gameObject.CompareTag("Player"))  //Playerに取られたら行われる処理  
        {
            getTrigger = true;
            Destroy(this.gameObject);
            goodSystem.GoodNum += 10f;
            Debug.Log("コメントを取得しました");
        }
    }
}
