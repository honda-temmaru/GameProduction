using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodAction1State : IPlayerState
{
    PlayerAnimationController anim;

    public GoodAction1State(PlayerAnimationController anim)
    {
        this.anim = anim;
    }

    public void Enter()
    {
        Debug.Log("いいねアクション1状態に移行");
        anim.PlayGoodAction1();
    }

    public void Update()
    {

    }

    public void Exit()
    {
        Debug.Log("いいねアクション1状態を終了");
    }
}

