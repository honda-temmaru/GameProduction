using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者：桑原大悟

public class GoodAction : MonoBehaviour
{
    [Header("イイネアクション1発動に必要ないいね数")]
    [SerializeField] int goodCost1 = 100;
    [Header("イイネアクション2発動に必要ないいね数")]
    [SerializeField] int goodCost2 = 100;
    [Header("イイネアクション3発動に必要ないいね数")]
    [SerializeField] int goodCost3 = 100;
    [Header("イイネアクション4発動に必要ないいね数")]
    [SerializeField] int goodCost4 = 100;

    [Header("必要なコンポーネント")]
    [SerializeField] GoodSystem goodSystem;
    [SerializeField] WideRangeAttack wideAttack;
    [SerializeField] LongRangeAttack longRangeAttack;
    [SerializeField] ContinuosHitAttack continuosHitAttack;
    [SerializeField] ExplosionAttack explosionAttack;

    float currentGoodNum = 0;
    int currentGoodPoint1 = 0;
    int currentGoodPoint2 = 0;
    int currentGoodPoint3 = 0;
    int currentGoodPoint4 = 0;

    public float CurrentGoodNum { get { return currentGoodNum; } }

    public int GoodCost1 { get { return goodCost1; } }
    public int GoodCost2 { get { return goodCost2; } }
    public int GoodCost3 { get { return goodCost3; } }
    public int GoodCost4 {  get { return goodCost4; } }

    public int CurrentGoodPoint1 { get { return currentGoodPoint1; } }
    public int CurrentGoodPoint2 { get {  return currentGoodPoint2; } }
    public int CurrentGoodPoint3 { get {  return currentGoodPoint3; } }
    public int CurrentGoodPoint4 { get {  return currentGoodPoint4; } }

    

    void Start()
    {
        currentGoodNum = goodSystem.GoodNum;
    }

    void Update()
    {
        float delta = goodSystem.GoodNum - currentGoodNum;

        if (delta <= 0) return; //いいねが増えていない場合は何もしない

        if (currentGoodPoint1 < goodCost1) currentGoodPoint1 += (int)delta;

        if (currentGoodPoint2 < goodCost2) currentGoodPoint2 += (int)delta;

        if (currentGoodPoint3 < goodCost3) currentGoodPoint3 += (int)delta;

        if (currentGoodPoint4 < goodCost4) currentGoodPoint4 += (int)delta;

        //蓄積ポイントが上限を超えないように補正する
        currentGoodPoint1 = Mathf.Min(currentGoodPoint1, goodCost1);
        currentGoodPoint2 = Mathf.Min(currentGoodPoint2, goodCost2);
        currentGoodPoint3 = Mathf.Min(currentGoodPoint3, goodCost3);
        currentGoodPoint4 = Mathf.Min(currentGoodPoint4, goodCost4);

        currentGoodNum = goodSystem.GoodNum;
    }

    public void GoodAction1()
    {
        if (currentGoodPoint1 < goodCost1) return;

        wideAttack.InstantiateWideRangeAttack();
        Debug.Log("イイネアクション1発動！");
        currentGoodPoint1 = 0;
    }

    public void GoodAction2()
    {
        if (currentGoodPoint2 < goodCost2) return;

        longRangeAttack.ShotBeam();
        Debug.Log("イイネアクション2発動！");
        currentGoodPoint2 = 0;
    }

    public void GoodAction3()
    {
        if (currentGoodPoint3 < goodCost3) return;

        continuosHitAttack.GenerateAttack();
        Debug.Log("イイネアクション3発動！");
        currentGoodPoint3 = 0;
    }

    public void GoodAction4()
    {
        if (currentGoodPoint4 < goodCost4) return;

        explosionAttack.TriggerExplosions();
        Debug.Log("イイネアクション4発動！");
        currentGoodPoint4 = 0;
    }
}
