using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotState : IPlayerState
{
    PlayerAnimationController anim;
    ShotAttack shotAttack;

    public ShotState(PlayerAnimationController anim, ShotAttack shotAttack)
    {
        this.anim = anim;
        this.shotAttack = shotAttack;
    }

    public void Enter()
    {
        //Debug.Log("‰“‹——£UŒ‚ó‘Ô‚ÉˆÚs");
        anim.PlayShotAttack();
    }

    public void Update()
    {
        shotAttack.ShotAttackProcess();

        if (shotAttack.TimeSinceLastShot >= shotAttack.ChangeStateInterval) PlayerInputEvents.IdleInput();
    }

    public void Exit()
    {
        shotAttack.TimeSinceLastShot = 0;
        //Debug.Log("‰“‹——£ó‘Ô‚ğI—¹");
    }
}
