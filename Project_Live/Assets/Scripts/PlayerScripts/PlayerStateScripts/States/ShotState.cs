using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class ShotState : IPlayerState
{
    PlayerAnimationController anim;
    MovePlayer movePlayer;
    ShotAttack shotAttack;

    public ShotState(PlayerAnimationController anim, MovePlayer movePlayer, ShotAttack shotAttack)
    {
        this.anim = anim;
        this.movePlayer = movePlayer;
        this.shotAttack = shotAttack;
    }

    public void Enter()
    {
        //Debug.Log("遠距離攻撃状態に移行");
        shotAttack.TimeSinceLastShot = shotAttack.ShotInterval; //初回のみ、入力後即発射できるようにする
    }

    public void Update()
    {
        shotAttack.ShotAttackProcess();

        if (shotAttack.HasPlayAnim)
        {
            anim.PlayShotAttack();
            shotAttack.HasPlayAnim = false;
        }

        if (shotAttack.CanMovingShot) movePlayer.MoveProcess_AnyAttackState(); //遠距離攻撃中に移動する

        if (!shotAttack.IsCharging && shotAttack.TimeSinceLastShot >= shotAttack.ChangeStateInterval)
            PlayerActionEvents.IdleEvent(); //弾を発射してから一定時間経過後、待機状態に移行する
    }

    public void Exit()
    {
        shotAttack.TimeSinceLastShot = 0;
        //Debug.Log("遠距離状態を終了");
    }
}
