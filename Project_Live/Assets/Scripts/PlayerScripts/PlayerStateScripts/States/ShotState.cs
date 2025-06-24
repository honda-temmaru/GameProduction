using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

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
        //Debug.Log("�������U����ԂɈڍs");
        shotAttack.TimeSinceLastShot = shotAttack.ShotInterval; //����̂݁A���͌㑦���˂ł���悤�ɂ���
    }

    public void Update()
    {
        shotAttack.ShotAttackProcess();

        if (shotAttack.HasPlayAnim)
        {
            anim.PlayShotAttack();
            shotAttack.HasPlayAnim = false;
        }

        if (shotAttack.CanMovingShot) movePlayer.MoveProcess_AnyAttackState(); //�������U�����Ɉړ�����

        if (!shotAttack.IsCharging && shotAttack.TimeSinceLastShot >= shotAttack.ChangeStateInterval)
            PlayerActionEvents.IdleEvent(); //�e�𔭎˂��Ă����莞�Ԍo�ߌ�A�ҋ@��ԂɈڍs����
    }

    public void Exit()
    {
        shotAttack.TimeSinceLastShot = 0;
        //Debug.Log("��������Ԃ��I��");
    }
}
