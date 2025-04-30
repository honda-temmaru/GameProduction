//作成者　寺村

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodSystem : MonoBehaviour
{
    [Header("いいね数のテキスト")]
    [SerializeField] TextMeshProUGUI goodText;
    float goodNum;    //いいね数
    public float GoodNum { get { return goodNum; } set { goodNum = value; } } //いいね数のゲッターとセッター

    // Start is called before the first frame update
    void Start()
    {
        goodNum = 0;    //開始時はゼロ
    }

    // Update is called once per frame
    void Update()
    {
        goodText.text = goodNum.ToString();     //いいね数をstringに変換して画面に表示
        Debug.Log(goodNum);
    }
}
