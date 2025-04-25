using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者：桑原大悟

public class GoodAction : MonoBehaviour
{
    [Header("イイネアクション1の再使用までの時間")]
    [SerializeField] float intervalA = 3f;
    [Header("イイネアクション2の再使用までの時間")]
    [SerializeField] float intervalB = 3f;
    [Header("イイネアクション3の再使用までの時間")]
    [SerializeField] float intervalC = 3f;
    [Header("イイネアクション4の再使用までの時間")]
    [SerializeField] float intervalD = 3f;

    private float actionTimerA = 0f;
    private float actionTimerB = 0f;
    private float actionTimerC = 0f;
    private float actionTimerD = 0f;

    void Start()
    {
        actionTimerA = intervalA; actionTimerB = intervalB;
        actionTimerC = intervalC; actionTimerD = intervalD;
    }

    void Update()
    {
        if (actionTimerA < intervalA)
            actionTimerA += Time.deltaTime;

        if (actionTimerB < intervalB)
            actionTimerB += Time.deltaTime;

        if (actionTimerC < intervalC)
            actionTimerC += Time.deltaTime;

        if (actionTimerD < intervalD)
            actionTimerD += Time.deltaTime;
    }

    public void GoodAction1()
    {
        if (actionTimerA < intervalA) return;

        Debug.Log("イイネアクション1発動！");
        actionTimerA = 0f;
    }

    public void GoodAction2()
    {
        if (actionTimerB < intervalB) return;

        Debug.Log("イイネアクション2発動！");
        actionTimerB = 0f;
    }

    public void GoodAction3()
    {
        if (actionTimerC < intervalC) return;

        Debug.Log("イイネアクション3発動！");
        actionTimerC = 0f;
    }

    public void GoodAction4()
    {
        if (actionTimerD < intervalD) return;

        Debug.Log("イイネアクション4発動！");
        actionTimerD = 0f;
    }
}
