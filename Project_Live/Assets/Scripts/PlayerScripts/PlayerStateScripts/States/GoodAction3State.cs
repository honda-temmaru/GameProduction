using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class GoodAction3State : IPlayerState
{
    PlayerAnimationController anim;
    GoodAction goodAction;

    float currentStateTime = 0f;
    bool isActionActivated = false;

    public GoodAction3State(PlayerAnimationController anim, GoodAction goodAction)
    {
        this.anim = anim;
        this.goodAction = goodAction;
    }

    public void Enter()
    {
        //Debug.Log("いいねアクション3状態に移行");
        anim.PlayGoodAction3();
    }

    public void Update()
    {
        currentStateTime += Time.deltaTime;

        if (currentStateTime < goodAction.GoodAction3Parameters.ActionInterval) return;

        if (!isActionActivated)
        {
            goodAction.GoodAction3();
            isActionActivated = true;
        }

        if (currentStateTime < goodAction.GoodAction3Parameters.ChangeStateInterval) return;

        PlayerActionEvents.IdleEvent();
    }

    public void Exit()
    {
        currentStateTime = 0f;
        isActionActivated = false;
        //Debug.Log("いいねアクション3状態を終了");
    }
}
