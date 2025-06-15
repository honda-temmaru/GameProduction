using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodAction3State : IPlayerState
{
    PlayerAnimationController anim;
    GoodAction goodAction;

    public GoodAction3State(PlayerAnimationController anim, GoodAction goodAction)
    {
        this.anim = anim;
        this.goodAction = goodAction;
    }

    public void Enter()
    {
        Debug.Log("いいねアクション3状態に移行");
        anim.PlayGoodAction3();
    }

    public void Update()
    {

    }

    public void Exit()
    {
        Debug.Log("いいねアクション3状態に移行");
    }
}
