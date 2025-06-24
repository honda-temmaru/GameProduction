using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class GoodAction4State : IPlayerState
{
    PlayerAnimationController anim;
    GoodAction goodAction;

    float currentStateTime = 0f;
    bool isActionActivated = false;

    public GoodAction4State(PlayerAnimationController anim, GoodAction goodAction)
    {
        this.anim = anim;
        this.goodAction = goodAction;
    }

    public void Enter()
    {
        //Debug.Log("�����˃A�N�V����4��ԂɈڍs");
        anim.PlayGoodAction4();
    }

    public void Update()
    {
        currentStateTime += Time.deltaTime;

        if (currentStateTime < goodAction.GoodAction4Parameters.ActionInterval) return;

        if (!isActionActivated)
        {
            goodAction.GoodAction4();
            isActionActivated = true;
        }

        if (currentStateTime < goodAction.GoodAction4Parameters.ChangeStateInterval) return;

        PlayerActionEvents.IdleEvent();
    }

    public void Exit()
    {
        currentStateTime = 0f;
        isActionActivated = false;
        //Debug.Log("�����˃A�N�V����4��Ԃ��I��");
    }
}
