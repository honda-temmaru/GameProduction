using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原大悟

public class IdleState : IPlayerState
{
    PlayerAnimationController anim;

    public IdleState(PlayerAnimationController anim)
    {
        if (anim == null)
        {
            Debug.Log("error");
            return;
        }

        this.anim = anim;
    }

    public void Enter()
    {
        if (anim == null)
        {
            Debug.Log("missEnter");
            return;
        }
        //Debug.Log("待機状態に移行");
        anim.PlayIdle();

    }

    public void Update()
    {

    }

    public void Exit()
    {
        //Debug.Log("待機状態終了");
    }
}
