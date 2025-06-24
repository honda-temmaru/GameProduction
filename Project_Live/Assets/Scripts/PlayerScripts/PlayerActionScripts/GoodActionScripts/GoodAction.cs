using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬�ҁF�K�����

[System.Serializable]
public class GoodActionParameters
{
    [Header("�����ɕK�v�Ȃ����ː�")]
    [SerializeField] int goodCost = 100;
    [Header("�U������������܂ł̎���")]
    [SerializeField] float actionInterval = 1f;
    [Header("�ҋ@��ԂɈڍs����܂ł̎���")]
    [SerializeField] float changeStateInterval = 2f;

    public int GoodCost { get { return goodCost; } }
    public float ActionInterval { get { return actionInterval;} }
    public float ChangeStateInterval { get { return changeStateInterval;} }
}

public class GoodAction : MonoBehaviour
{
    [Header("�C�C�l�A�N�V����1")]
    [SerializeField] GoodActionParameters goodAction1;
    [Header("�C�C�l�A�N�V����2")]
    [SerializeField] GoodActionParameters goodAction2;
    [Header("�C�C�l�A�N�V����3")]
    [SerializeField] GoodActionParameters goodAction3;
    [Header("�C�C�l�A�N�V����4")]
    [SerializeField] GoodActionParameters goodAction4;

    [Header("�K�v�ȃR���|�[�l���g")]
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

    public GoodActionParameters GoodAction1Parameters { get { return goodAction1; } }
    public GoodActionParameters GoodAction2Parameters { get { return goodAction2; } }
    public GoodActionParameters GoodAction3Parameters { get { return goodAction3; } }
    public GoodActionParameters GoodAction4Parameters { get { return goodAction4; } }

    public float CurrentGoodNum { get { return currentGoodNum; } }

    public int GoodCost1 { get { return goodAction1.GoodCost; } }
    public int GoodCost2 { get { return goodAction2.GoodCost; } }
    public int GoodCost3 { get { return goodAction3.GoodCost; } }
    public int GoodCost4 {  get { return goodAction4.GoodCost; } }

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

        if (delta <= 0) return; //�����˂������Ă��Ȃ��ꍇ�͉������Ȃ�

        if (currentGoodPoint1 < goodAction1.GoodCost) currentGoodPoint1 += (int)delta;
        if (currentGoodPoint2 < goodAction2.GoodCost) currentGoodPoint2 += (int)delta;
        if (currentGoodPoint3 < goodAction3.GoodCost) currentGoodPoint3 += (int)delta;
        if (currentGoodPoint4 < goodAction4.GoodCost) currentGoodPoint4 += (int)delta;

        //�~�σ|�C���g������𒴂��Ȃ��悤�ɕ␳����
        currentGoodPoint1 = Mathf.Min(currentGoodPoint1, goodAction1.GoodCost);
        currentGoodPoint2 = Mathf.Min(currentGoodPoint2, goodAction2.GoodCost);
        currentGoodPoint3 = Mathf.Min(currentGoodPoint3, goodAction3.GoodCost);
        currentGoodPoint4 = Mathf.Min(currentGoodPoint4, goodAction4.GoodCost);

        currentGoodNum = goodSystem.GoodNum;
    }

    public void GoodAction1()
    {
        if (currentGoodPoint1 < goodAction1.GoodCost) return;

        wideAttack.InstantiateWideRangeAttack();
        Debug.Log("�C�C�l�A�N�V����1�����I");
        currentGoodPoint1 = 0;
    }

    public void GoodAction2()
    {
        if (currentGoodPoint2 < goodAction2.GoodCost) return;

        longRangeAttack.ShotBeam();
        Debug.Log("�C�C�l�A�N�V����2�����I");
        currentGoodPoint2 = 0;
    }

    public void GoodAction3()
    {
        if (currentGoodPoint3 < goodAction3.GoodCost) return;

        continuosHitAttack.GenerateAttack();
        Debug.Log("�C�C�l�A�N�V����3�����I");
        currentGoodPoint3 = 0;
    }

    public void GoodAction4()
    {
        if (currentGoodPoint4 < goodAction4.GoodCost) return;

        explosionAttack.TriggerExplosions();
        Debug.Log("�C�C�l�A�N�V����4�����I");
        currentGoodPoint4 = 0;
    }
}
