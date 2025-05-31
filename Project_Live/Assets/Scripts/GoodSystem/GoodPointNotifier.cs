using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPointNotifier : MonoBehaviour
{
    [SerializeField] GoodAction goodAction;

    public event System.Action<int, int> OnGoodPointChanged;

    int[] prevPoints = new int[4];

    void Update()
    {
        CheckAndNotify(1, goodAction.CurrentGoodPoint1);
        CheckAndNotify(2, goodAction.CurrentGoodPoint2);
        CheckAndNotify(3, goodAction.CurrentGoodPoint3);
        CheckAndNotify(4, goodAction.CurrentGoodPoint4);
    }

    void CheckAndNotify(int index, int current) //各いいねポイントの蓄積量に変化があったら知らせる
    {
        if (prevPoints[index - 1] == current) return; //変化がなかったら何もしない
        
        OnGoodPointChanged?.Invoke(index, current); //イベントの発火と同時に、通知先に番号と対応するいいねポイント数を渡す
        prevPoints[index - 1] = current;
    }
}
