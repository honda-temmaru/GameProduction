using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IPlayerState
{
    PlayerAnimationController anim;
    MovePlayer movePlayer;

    public MoveState(PlayerAnimationController anim, MovePlayer movePlayer)
    {
        this.anim = anim;
        this.movePlayer = movePlayer;
    }

    public void Enter()
    {
        anim.PlayMove();
        Debug.Log("ˆÚ“®ó‘Ô‚ÉˆÚs");
    }

    public void Update()
    {
        movePlayer.MoveProcess(); //ˆÚ“®‚Ìˆ—
    }

    public void Exit()
    {
        anim.PlayIdle();
        Debug.Log("ˆÚ“®ó‘Ô‚ğI—¹");
    }
}
