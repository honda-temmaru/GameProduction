using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

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
        //Debug.Log("�ړ���ԂɈڍs");
    }

    public void Update()
    {
        movePlayer.MoveProcess(); //�ړ��̏���
    }

    public void Exit()
    {
        //Debug.Log("�ړ���Ԃ��I��");
    }
}
