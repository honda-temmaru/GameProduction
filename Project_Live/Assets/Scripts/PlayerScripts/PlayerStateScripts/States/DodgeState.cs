using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ÒFŒKŒ´

public class DodgeState : IPlayerState
{
    PlayerAnimationController anim;
    MovePlayer movePlayer;
    Dodge dodge;

    public DodgeState(PlayerAnimationController anim, MovePlayer movePlayer, Dodge dodge)
    {
        this.anim = anim;
        this.movePlayer = movePlayer;
        this.dodge = dodge;
    }

    public void Enter()
    {
        //Debug.Log("‰ñ”ğó‘Ô‚ÉˆÚs");
        anim.PlayDodge();
        dodge.TryDodge();
    }

    public void Update()
    {
        dodge.DodgeProcess();
    }

    public void Exit()
    {
        //Debug.Log("‰ñ”ğó‘Ô‚ğI—¹");
    }
}

