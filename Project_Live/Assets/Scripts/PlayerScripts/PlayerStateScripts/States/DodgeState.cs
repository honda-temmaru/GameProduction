using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : IPlayerState
{
    PlayerAnimationController anim;

    public DodgeState(PlayerAnimationController anim)
    {
        this.anim = anim;
    }

    public void Enter()
    {
        Debug.Log("‰ñ”ğó‘Ô‚ÉˆÚs");
        anim.PlayDodge();
    }

    public void Update()
    {

    }

    public void Exit()
    {
        Debug.Log("‰ñ”ğó‘Ô‚ğI—¹");
    }
}

