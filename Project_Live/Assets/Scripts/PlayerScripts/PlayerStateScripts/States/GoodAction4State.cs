using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodAction4State : IPlayerState
{
    PlayerAnimationController anim;

    public GoodAction4State(PlayerAnimationController anim)
    {
        this.anim = anim;
    }

    public void Enter()
    {
        Debug.Log("いいねアクション4状態に移行");
        anim.PlayGoodAction4();
    }

    public void Update()
    {

    }

    public void Exit()
    {
        Debug.Log("いいねアクション4状態を終了");
    }
}
