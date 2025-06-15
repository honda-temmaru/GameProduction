using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodAction1State : IPlayerState
{
    PlayerAnimationController anim;
    GoodAction goodAction;

    float currentStateTime = 0f;

    public GoodAction1State(PlayerAnimationController anim, GoodAction goodAction)
    {
        this.anim = anim;
        this.goodAction = goodAction;
    }

    public void Enter()
    {
        Debug.Log("いいねアクション1状態に移行");
        anim.PlayGoodAction1();
    }

    public void Update()
    {
        currentStateTime += Time.deltaTime;

        if (currentStateTime < goodAction.GoodAction1Parameters.ActionInterval) return;

        goodAction.GoodAction1();
    }

    public void Exit()
    {
        Debug.Log("いいねアクション1状態を終了");
    }
}

