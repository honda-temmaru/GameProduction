using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodAction2State : IPlayerState
{
    PlayerAnimationController anim;
    GoodAction goodAction;

    public GoodAction2State(PlayerAnimationController anim, GoodAction goodAction)
    {
        this.anim = anim;
        this.goodAction = goodAction;
    }

    public void Enter()
    {
        Debug.Log("いいねアクション状態に移行");
        anim.PlayGoodAction2();
    }

    public void Update()
    {

    }

    public void Exit()
    {
        Debug.Log("いいねアクション状態を終了");
    }
}
