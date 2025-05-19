using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者：桑原

public class GoodPointDisplay : MonoBehaviour
{
    [Header("いいねアクション1に使用するポイント蓄積量表示用テキスト")]
    [SerializeField] TextMeshProUGUI goodPointText1;
    [Header("いいねアクション2に使用するポイント蓄積量表示用テキスト")]
    [SerializeField] TextMeshProUGUI goodPointText2;
    [Header("いいねアクション3に使用するポイント蓄積量表示用テキスト")]
    [SerializeField] TextMeshProUGUI goodPointText3;
    [Header("いいねアクション4に使用するポイント蓄積量表示用テキスト")]
    [SerializeField] TextMeshProUGUI goodPointText4;

    [Header("必要なコンポーネント")]
    [SerializeField] GoodAction goodAction;

    void Update()
    {
        //現在の各いいねアクション用のポイント蓄積量を画面に表示
        goodPointText1.text = "GP1:" + goodAction.CurrentGoodPoint1.ToString();
        goodPointText2.text = "GP2:" + goodAction.CurrentGoodPoint2.ToString();
        goodPointText3.text = "GP3:" + goodAction.CurrentGoodPoint3.ToString();
        goodPointText4.text = "GP4:" + goodAction.CurrentGoodPoint4.ToString();
    }
}
